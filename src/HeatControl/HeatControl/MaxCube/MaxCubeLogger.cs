using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HeatControl.OTGW;
using System.IO;

namespace HeatControl
{
    partial class MaxCubeLogger
    {
        public class StatusReport
        {
            public class Radiator
            {
                public string name;
                public float valve;

                public Radiator(string name, float valve)
                {
                    this.name = name;
                    this.valve = valve;
                }
            }

            public class RoomReport
            {
                public string name;
                public float configuredTemperature;
                public float actualTemperature;
                public List<Radiator> radiators;
                public bool boostActive;

                public RoomReport(string name, float configuredTemperature, float actualTemperature, bool boostActive) 
                { 
                    this.radiators = new List<Radiator>();
                    this.name = name;
                    this.configuredTemperature = configuredTemperature;
                    this.actualTemperature = actualTemperature;
                    this.boostActive = boostActive;
                }
            }

            public DateTime dateTime;
            public List<RoomReport> report;

            public StatusReport(MaxCubeLogger maxCubeLogger) 
            {
                this.dateTime= DateTime.Now;
                this.report= new List<RoomReport>();

                foreach(MaxCube maxCube in maxCubeLogger.maxCubes)
                {
                    foreach(KeyValuePair<int,MaxCube.Room> kvp in maxCube.rooms)
                    {
                        MaxCube.Room room = kvp.Value;
                        if (room.roomID != 0)
                        {
                            RoomReport roomReport = new RoomReport(room.name, room.configuredTemperature, room.actualTemperature, room.boostActive);

                            foreach (MaxCube.DeviceBase device in room.devices)
                            {
                                if ((device.type == MaxCube.DeviceType.HeatingThermostat) || (device.type == MaxCube.DeviceType.HeatingThermostatTODO))
                                {
                                    MaxCube.DeviceHeatingThermostat heatingThermostat = (MaxCube.DeviceHeatingThermostat)device;
                                    roomReport.radiators.Add(new Radiator(heatingThermostat.name, heatingThermostat.valvePosition));
                                }
                            }
                            this.report.Add(roomReport);
                        }
                    }

                    // request new real-time status report from the devices.
                    maxCube.EnqueueCommand("l:");
                }
            }

            public string Heading()
            {
                string s = "Date Time; ";

                foreach(RoomReport roomReport in this.report)
                {
                    s += roomReport.name + " configured temperature; ";
                    s += roomReport.name + " actual temperature; ";
                    foreach (Radiator radiator in roomReport.radiators)
                    {
                        s += roomReport.name + radiator.name + " percentage; ";
                    }
                }
                return s;
            }

            override public string ToString()
            {
                string s = this.dateTime.ToString() + "; ";

                foreach (RoomReport roomReport in this.report)
                {
                    s += roomReport.configuredTemperature.ToString() + "; ";
                    s += roomReport.actualTemperature.ToString() + "; ";
                    foreach (Radiator radiator in roomReport.radiators) 
                    {
                        s += radiator.valve.ToString() + "; ";
                    }
                }
                return s;
            }
        }

        public delegate void StatusReportHandler(StatusReport status);
        private List<StatusReportHandler> statusReportHandlers;


        public void AddStatusReporter(StatusReportHandler handler)
        {
            this.statusReportHandlers.Add(handler);
        }

        public void RemoveStatusReporter(StatusReportHandler handler)
        {
            this.statusReportHandlers.Remove(handler);
        }


        public MaxCubeLogger()
        {
            this.statusReportHandlers = new List<StatusReportHandler>();
            this.maxCubes = new List<MaxCube>();
            this.logHandlers = new List<LogHandler>();

            this.stateMachineShouldClose = false;
            this.stateMachine = new Thread(StateMachine);
            this.stateMachine.IsBackground = true;
            this.stateMachine.Start();
        }

        public string hostName;

        public List<MaxCube> maxCubes;


        public delegate void LogHandler(string text);
        private List<LogHandler> logHandlers;
        private void Log(string text)
        {
            Console.WriteLine(text);
            foreach (LogHandler logHandler in logHandlers)
            {
                logHandler(text);
            }

        }
        public void AddLogger(LogHandler handler)
        {
            this.logHandlers.Add(handler);
        }

        public void RemoveLogger(LogHandler handler)
        {
            this.logHandlers.Remove(handler);
        }

        public enum StateRequest
        {
            Disconnected = 0,
            Connect = 1,
            Running = 2,
            Disconnect = 3,
        };

        private Thread stateMachine;
        private volatile bool stateMachineShouldClose;
        private volatile bool stateMachineHasClosed;
        public volatile StateRequest stateRequest;

        public const int statusReportInterval = 10;

        private void StateMachine()
        {
            long lastStatusReportTick = 0;

            stateMachineHasClosed = false;
            stateRequest = StateRequest.Disconnected;
            while (this.stateMachineShouldClose == false)
            {
                switch (stateRequest)
                {
                    case StateRequest.Disconnected:
                        break;
                    case StateRequest.Connect:
                        Connect();
                        stateRequest = StateRequest.Running;
                        break;
                    case StateRequest.Running:
                        break;
                    case StateRequest.Disconnect:
                        Disconnect();
                        stateRequest = StateRequest.Disconnected;
                        break;
                }

                if (stateRequest == StateRequest.Running)
                {
                    if ((DateTime.Now.Ticks - lastStatusReportTick) > (statusReportInterval * System.TimeSpan.TicksPerSecond))
                    {
                        // check if we can generate a valid StatusReport
                        bool allValid = true;
                        foreach (MaxCube maxCube in maxCubes)
                        {
                            if (maxCube.configurationReceived == false)
                            {
                                allValid = false;
                            }
                        }

                        if (allValid)
                        {
                            StatusReport statusReport = new StatusReport(this);

                            foreach (StatusReportHandler statusReportHandler in statusReportHandlers)
                            {
                                statusReportHandler(statusReport);
                            }
                        }
                        lastStatusReportTick = DateTime.Now.Ticks;
                    }
                }






                Thread.Sleep(100); // we could make this event driven somehow....
            }
            stateMachineHasClosed = true;
        }

        public void Connect()
        {
            // remove any previously found MaxCubes
            this.maxCubes.Clear();

            if ((this.hostName == null) || (this.hostName.Equals("")))
            {
                // hostname is empty string, let's find the IP-adress(es) automagically
                this.findCubeIPAddress();
            }
            else
            {
                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(hostName);

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    if (curAdd.AddressFamily == AddressFamily.InterNetwork) // we only do IPv4. Not IPv6
                    {
                        this.maxCubes.Add(new MaxCube(this, curAdd, hostName, "", -1, ""));
                        this.Log("IP-Address: " + curAdd.ToString());
                        break;
                    }
                }

                if (this.maxCubes.Count == 0)
                {
                    throw new Exception("Hostname or IP-address " + hostName + "not resolvable.");
                }
            }

            // open connection to all cubes
            foreach (MaxCube cube in this.maxCubes)
            {
                cube.Connect();
            }
        }

        public void Disconnect()
        {
            foreach (MaxCube cube in this.maxCubes)
            {
                cube.Disconnect();
            }
        }

        public bool IsConnected()
        {
            bool r = true;
            foreach (MaxCube cube in this.maxCubes)
            {
                if (!cube.IsConnected()) r = false;
            }
            return r;
        }

        private static string GetLocalIPAddress()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            return localIP;
        }

        private void findCubeIPAddress()
        {
            const int port = 23272;

            string localIP = GetLocalIPAddress();
            string broadcastIP = localIP.Substring(0, IndexOfNthSB(localIP, '.', 0, 3) + 1) + "255";

            UdpClient udpClient = new UdpClient() { EnableBroadcast = true };
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, port));
            IPEndPoint from = new IPEndPoint(0, 0);

            byte[] identifyData = { 0x65, 0x51, 0x33, 0x4d, 0x61, 0x78, 0x2a, 0x00, 0x2a, 0x2a, 0x2a, 0x2a, 0x2a, 0x2a, 0x2a, 0x2a, 0x2a, 0x2a, 0x49 };
            udpClient.Send(identifyData, identifyData.Length, broadcastIP, port);

            byte[] receiveBuffer;

            do
            {
                receiveBuffer = UdpClientReadTimeOut(udpClient, ref from, 2);
                if (receiveBuffer.Length == 26)
                {
                    string t = System.Text.Encoding.UTF8.GetString(receiveBuffer);
                    IPAddress ip = from.Address;
                    string name = t.Substring(0, 8);
                    string serial = t.Substring(8, 10);
                    int RFaddress = MaxCube.GetRfAddress(receiveBuffer,21);
                    string version = t[24].ToString() + "." + (t[25] >>4).ToString() + "." + (t[25]&0x0f).ToString();

                    if (!serial.Equals("**********"))
                    {
                        this.Log("Found MaxCube @ " + ip.ToString());
                        this.maxCubes.Add(new MaxCube(this, ip, name, serial, RFaddress, version));
                    }
                }
            }
            while (receiveBuffer.Length != 0);

            udpClient.Close();
            return;
        }

        private static int IndexOfNthSB(string input, char value, int startIndex, int nth)
        {
            if (nth < 1)
                throw new NotSupportedException("Param 'nth' must be greater than 0!");
            var nResult = 0;
            for (int i = startIndex; i < input.Length; i++)
            {
                if (input[i] == value)
                    nResult++;
                if (nResult == nth)
                    return i;
            }
            return -1;
        }

        private static byte[] UdpClientReadTimeOut(UdpClient udpClient, ref IPEndPoint from, int timeOut)
        {
            byte[] recvBuffer = { };
            int counter = timeOut * 10;
            while ((udpClient.Available == 0) && (counter > 0))
            {
                System.Threading.Thread.Sleep(100);
                counter--;
            }
            if (udpClient.Available != 0)
            {
                recvBuffer = udpClient.Receive(ref from);
            }
            return recvBuffer;
        }




        
    }
}
