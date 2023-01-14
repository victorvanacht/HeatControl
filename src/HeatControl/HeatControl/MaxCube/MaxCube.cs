using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HeatControl.OTGW;

namespace HeatControl
{
    partial class MaxCubeLogger
    { 
        public partial class MaxCube
        {
            public IPAddress iPAddress;
            public string name;
            public string serial;
            public int RFAddress;
            public string version;
            public int dutyCycle;
            public int freeMemorySlots;
            public DateTime dateTime;

            private SocketReader socketReader;
            private Parser parser;
            private MaxCubeLogger maxCubeLogger;

            public MaxCube(MaxCubeLogger maxCubeLogger, IPAddress iPAddress, string name, string serial, int RFAddress, string version)
            {
                this.maxCubeLogger = maxCubeLogger;
                this.iPAddress = iPAddress;
                this.name = name;
                this.serial = serial;
                this.RFAddress = RFAddress;
                this.version = version;

                this.socketReader = new SocketReader(maxCubeLogger, this);
                this.parser= new Parser(this);


            }

            public void Connect()
            {
                this.socketReader.Connect();

                if (this.socketReader.IsConnected())
                {
                    this.socketThreadShouldClose = false;
                    this.socketThread = new Thread(SocketThread);
                    this.socketThread.IsBackground = true;
                    this.socketThread.Start();
                }

                /*
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
                */


            }

            public void Disconnect()
            {
                this.socketThreadShouldClose = true;
                this.socketThread.Join();
                this.socketReader.Disconnect();
            }


            private Thread socketThread;
            private volatile bool socketThreadShouldClose;
            private volatile bool socketThreadHasClosed;
            private void SocketThread()
            {
                //long lastStatusReportTick = 0;

                socketThreadHasClosed = false;
                while (socketThreadShouldClose == false)
                {
                    string[] lines = socketReader.ReadLines();
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            maxCubeLogger.Log(DateTime.Now.ToString() + " R:" + line);
                            this.parser.Parse(line);
                        }

                        /*
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
                        */
                    }

                /*
                    if ((DateTime.Now.Ticks - lastStatusReportTick) > (statusReportInterval * System.TimeSpan.TicksPerSecond))
                    {
                        lastStatusReportTick = DateTime.Now.Ticks;

                        StatusReport statusReport = new StatusReport(this.gatewayStatus);
                        foreach (StatusReportHandler statusReportHandler in statusReportHandlers)
                        {
                            statusReportHandler(statusReport);
                        }
                    }
                */
                }
                socketThreadHasClosed = true;
            }
        }
    }
}
