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
using System.Net.Http.Headers;

namespace HeatControl
{
    partial class OTGW
    {
        private CommandQueue commandQueue;
        private Parser parser;

        public OTGW()
        {
            this.gatewayConfiguration = new GatewayConfiguration();
            this.gatewayStatus = new GatewayStatus();
            this.socketReader = new SocketReader(this);
            this.commandQueue = new CommandQueue();
            this.parser = new Parser(ref this.gatewayConfiguration, ref this.gatewayStatus, ref this.commandQueue);
            this.logHandlers = new List<LogHandler>();
            this.statusReportHandlers = new List<StatusReportHandler>();

            this.stateMachineShouldClose = false;
            this.stateMachine = new Thread(StateMachine);
            this.stateMachine.IsBackground = true;
            this.stateMachine.Start();
        }

        public delegate void LogHandler(string text);
        private List<LogHandler> logHandlers;
        private void Log(string text)
        {
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


        public const int statusReportInterval = 10;
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

        private void StateMachine()
        {
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
                Thread.Sleep(100); // we could make this event driven somehow....
            }
            stateMachineHasClosed = true;
        }

        public string hostName;

        public void Connect()
        {
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

        public bool IsConnected()
        {
            return socketReader.IsConnected();
        }

        public void SetBoilerTemp(double boilerTemperature)
        {
            string t = ((int)boilerTemperature).ToString();
            commandQueue.EnqueueCommand("CS=" + t);

            if (boilerTemperature < 1) // should be equal to 0, but it's a float.... so....
            {
                this.gatewayStatus.controlSetPointModified.value = 0; // this is to remove the modified control setpoint from the UI again.
            }
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
                        Log(DateTime.Now.ToString() + " R:" +line);
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
        }
    }
}


