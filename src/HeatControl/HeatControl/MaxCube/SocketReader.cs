using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace HeatControl
{
    partial class MaxCube
    {
        private class SocketReader
        {

            private const int port = 6638;

            private IPAddress ipAddress;
            private Socket socket;
            private MaxCube maxCube;


            // constructor
            public SocketReader(MaxCube maxCube)
            {
                this.maxCube = maxCube;
            }

            // destructor
            ~SocketReader()
            {
                Disconnect();
            }


            // hostname can be IP address such as "192.168.50.150" 
            // or can be host name such as "OTGW_wifi"
            public void Connect(string hostName)
            {
                if ((hostName == null) || (hostName.Equals("")))
                {
                    // hostname is empty string, let's find the IP-adress automagically
                    findCubeIPAddress();
                }

                // ### Find the IP address of the host

                /*


                this.ipAddress = null;

                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(hostName);

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    if (curAdd.AddressFamily == AddressFamily.InterNetwork) // we only do IPv4. Not IPv6
                    {
                        this.ipAddress = curAdd;
                        otgw.Log("IP-Address: " + this.ipAddress.ToString());
                    }
                }

                if (this.ipAddress == null)
                {
                    throw new Exception("Hostname or IP-address " + hostName + "not resolvable.");
                }


                this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.socket.Connect(new IPAddress[] { this.ipAddress }, port);
                this.socket.NoDelay = true;
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
                        string IPAddress = from.Address.ToString();
                        string name = t.Substring(0, 8);
                        string serial = t.Substring(8, 10);
                        int RFaddress = (receiveBuffer[21] << 16) + (receiveBuffer[22] << 8) + receiveBuffer[23];

                        if (!serial.Equals("**********"))
                        {
                            maxCube.Log("Found MaxCube @ " + IPAddress);
                            maxCube.cubes.Add(new Cube(IPAddress, name, serial, RFaddress));
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


            public void Disconnect()
            {
                /*
                try
                {
                    if (this.socket != null)
                    {
                        this.socket.Close();
                    }
                }
                catch
                {
                }
                this.socket = null;
                */
            }




            public bool IsConnected()
            {
                /*
                return this.socket != null;
                */
                return false;
            }

            /*

            private string readLinesLeftover = "";
            public string[] ReadLines()
            {
                string msg;
                string[] lines = { };

                Byte[] bytes = new byte[this.socket.ReceiveBufferSize];
                int bytesRecv = this.socket.Receive(bytes);
                if (bytesRecv > 0)
                {
                    msg = readLinesLeftover + Encoding.ASCII.GetString(bytes, 0, bytesRecv);

                    //remove any \r in the string, by splitting and rejoining it [This is the fastest way to do it, according to internet]
                    string[] temp = msg.Split('\r');
                    msg = string.Join("", temp);

                    // see if the message ends with CR. If not, chop it andf put the remaining part in leftover.
                    int lastIndex = msg.LastIndexOf('\n');
                    if (lastIndex == -1)
                    {
                        readLinesLeftover = msg;
                        msg = "";
                    }
                    else if (lastIndex != msg.Length - 1)
                    {
                        readLinesLeftover = msg.Substring(lastIndex + 1);
                        msg = msg.Substring(0, lastIndex + 1);
                    }
                    else
                    {
                        readLinesLeftover = "";
                    }


                    // split the message in separate lines by CR
                    lines = msg.Split('\n');
                }
                return lines;
            }

            public void WriteLine(string line)
            {
                Thread.Sleep(500); // for some reason we need to insert a wait here. Don't know why. But if we don't the OTGW doesnt respond.
                otgw.Log(DateTime.Now.ToString() + " T:" + line);

                byte[] msg = Encoding.ASCII.GetBytes(line + "\n\r");
                int byteSent = this.socket.Send(msg);
                if (byteSent != msg.Length)
                {
                    throw new Exception("Message not sent.");
                }
            }
            */
        }
    }
}
