using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HeatControl.OTGW;

namespace HeatControl
{
    partial class MaxCubeLogger
    {
        public MaxCubeLogger()
        {
            this.maxCubes = new List<MaxCube>();
            this.logHandlers = new List<LogHandler>();

        }

        public string hostName;

        List<MaxCube> maxCubes;


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

        public void Connect()
        {
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





            /*
            socketReader.Connect(this.hostName);

            if (this.socketReader.IsConnected())
            {
                this.socketThreadShouldClose = false;
                this.socketThread = new Thread(SocketThread);
                this.socketThread.IsBackground = true;
                this.socketThread.Start();
            }

            // first send three times PS=0 command to make sure that we receive log messages
            socketReader.WriteLine("PS=0\n\r");
            socketReader.WriteLine("PS=0\n\r");
            socketReader.WriteLine("PS=0\n\r");

            // send a list of commands to request configuration parameters
            string[] initCommands = {"PR=A", "PR=B", "PR=C", "PR=G", "PR=I", "PR=L", "PR=M", "PR=O", "PR=P", // "PR=D" command does not return a proper response
                                     "PR=Q", "PR=R", "PR=S", "PR=T", "PR=V", "PR=W" };
            foreach (string line in initCommands)
            {
                commandQueue.EnqueueCommand(line);
            }
        }

        public void Disconnect()
        {
            this.socketThreadShouldClose = true;
            this.socketThread.Join();
            socketReader.Disconnect();
        }

        private SocketReader socketReader;
        private Thread socketThread;
        private volatile bool socketThreadShouldClose;
        private volatile bool socketThreadHasClosed;
        private void SocketThread()
        {
            long lastStatusReportTick = 0;

            socketThreadHasClosed = false;
            while (socketThreadShouldClose == false)
            {
                string[] lines = socketReader.ReadLines();
                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        Log(DateTime.Now.ToString() + " R:" + line);
                        this.parser.Parse(line);
                    }

                    if (!commandQueue.IsEmpty())
                    {
                        CommandQueue.CommandQueueItem firstItem;
                        if (commandQueue.TryPeek(out firstItem))
                        {
                            if ((firstItem.retryAttempts == 0) ||
                                ((DateTime.Now.Ticks - firstItem.lastTransmitAttemptTick) > firstItem.retryDelayTicks))
                            {
                                if (firstItem.retryAttempts < firstItem.maxRetryAttempts)
                                {
                                    socketReader.WriteLine(firstItem.command);
                                    firstItem.retryAttempts++;
                                    firstItem.lastTransmitAttemptTick = DateTime.Now.Ticks;
                                }
                                else
                                {
                                    /// it failed!!
                                    Console.WriteLine("Command failed!");

                                    commandQueue.TryDequeueCommand(firstItem.command);
                                    //throw new Exception("Command failed!");
                                }
                            }
                        }
                    }
                }

                if ((DateTime.Now.Ticks - lastStatusReportTick) > (statusReportInterval * System.TimeSpan.TicksPerSecond))
                {
                    lastStatusReportTick = DateTime.Now.Ticks;

                    StatusReport statusReport = new StatusReport(this.gatewayStatus);
                    foreach (StatusReportHandler statusReportHandler in statusReportHandlers)
                    {
                        statusReportHandler(statusReport);
                    }
                }
            }
            socketThreadHasClosed = true;
            */
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
                    int RFaddress = (receiveBuffer[21] << 16) + (receiveBuffer[22] << 8) + receiveBuffer[23];
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
