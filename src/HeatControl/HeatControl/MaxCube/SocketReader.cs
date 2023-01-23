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
    partial class MaxCubeLogger
    {
        partial class MaxCube
        {
            private class SocketReader
            {

                private const int port = 62910;

                private IPAddress ipAddress;
                private Socket socket;
                private MaxCubeLogger maxCubeLogger;
                private MaxCube maxCube;


                // constructor
                public SocketReader(MaxCubeLogger maxCubeLogger, MaxCube maxCube)
                {
                    this.maxCubeLogger = maxCubeLogger;
                    this.maxCube = maxCube;
                    this.ipAddress = this.maxCube.iPAddress;
                }

                // destructor
                ~SocketReader()
                {
                    Disconnect();
                }

                public void Connect()
                {
                    this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.socket.Connect(new IPAddress[] { this.ipAddress }, port);
                    this.socket.NoDelay = true;
                    this.socket.Blocking = false;
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
                    try
                    {
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
                    }
                    catch (Exception e) { };
                    return lines;
                }

                public void WriteLine(string line)
                {
                    Console.WriteLine(line);

                    Thread.Sleep(500); // for some reason we need to insert a wait here. Don't know why. But if we don't the OTGW doesnt respond.
                    maxCubeLogger.Log(DateTime.Now.ToString() + " T:" + line);

                    byte[] msg = Encoding.ASCII.GetBytes(line + "\r\n");
                    int byteSent = this.socket.Send(msg);
                    if (byteSent != msg.Length)
                    {
                        throw new Exception("Message not sent.");
                    }
                }
            }
        }
    }
}
