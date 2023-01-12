using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HeatControl.OTGW;

namespace HeatControl
{
    partial class MaxCube
    {
        private SocketReader socketReader;

        public MaxCube()
        {
            this.cubes = new List<Cube>();
            this.logHandlers = new List<LogHandler>();
            this.socketReader = new SocketReader(this);

        }

        public string hostname;


        public class Cube
        {
            public string iPAddress;
            public string name;
            public string serial;
            public int RFAddress;

            public Cube(string iPAddress, string name, string serial, int RFAddress)
            {
                this.iPAddress = iPAddress;
                this.name = name;
                this.serial= serial;
                this.RFAddress = RFAddress;
            }
        }

        List<Cube> cubes;


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
            this.socketReader.Connect(this.hostname);
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
    }
}
