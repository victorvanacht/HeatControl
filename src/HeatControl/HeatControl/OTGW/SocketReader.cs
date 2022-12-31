using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace HeatControl
{
    partial class OTGW
    {
        class SocketReader
        {
            private const int port = 6638;

            private IPAddress ipAddress;
            private Socket socket;
            private OTGW otgw;


            // constructor
            public SocketReader(OTGW otgw)
            {
                this.otgw = otgw;
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
                // ### Find the IP address of the host


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
            }

            public void Disconnect()
            {
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
            }

            public bool IsConnected()
            {
                return this.socket != null;
            }

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
        }
    }
}
