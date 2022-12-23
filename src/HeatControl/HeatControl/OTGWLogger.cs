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
    class OTGW
    {
        public class GatewayConfiguration
        {
            public string version;
            public string build;
            public string clockSpeed;
            public string temperaturSensorFunction;
            public string gpioFunctionsConfiguration;
            public string gpioFunctionsCurrent;
            public string ledsFunctionsConfiguration;
            public string gatewayMode;
            public string setpointOverride;
            public string smartPowerModelCurrent;
            public string causeOfLastReset;
            public string remehaDetectionStart;
            public string setbackTemperatureConfiguarion;
            public string tweaks;
            public string referenceVoltage;
            public string hotWater;

        }
        public GatewayConfiguration gatewayConfiguration;



        private SocketReader socketReader;

        private Thread socketThread;
        private volatile bool socketThreadShouldClose;
        private volatile bool socketThreadHasClosed;



        private class CommandQueueItem
        {
            public string command;
            public int retryAttempts;
            public int maxRetryAttempts;
            public long enqueTick;
            public long lastTransmitAttemptTick;
            public long retryDelayTicks;

            public CommandQueueItem(string command) : this(command, 10, 3 * System.TimeSpan.TicksPerSecond) { }

            public CommandQueueItem(string command, int maxRetryAttempts, long retryDelayTicks)
            {
                this.command = command;
                this.retryAttempts = 0;
                this.maxRetryAttempts = maxRetryAttempts;
                this.enqueTick = DateTime.Now.Ticks;
                this.retryDelayTicks = retryDelayTicks;
            }

        }
        private ConcurrentQueue<CommandQueueItem> commandQueue;

        public void EnqueueCommand(string command)
        {
            CommandQueueItem item = new CommandQueueItem(command);
            commandQueue.Enqueue(item);
        }
        public bool TryDequeueCommand(string command)
        {
            if (!commandQueue.IsEmpty)
            {
                CommandQueueItem firstItem;
                if (commandQueue.TryPeek(out firstItem))
                {
                    if ((command.Length >= 2) && (firstItem.command.Length >= 2))
                    {
                        if (command.Substring(0, 2).ToUpper().Equals(firstItem.command.Substring(0, 2).ToUpper()))
                        {
                            return commandQueue.TryDequeue(out firstItem);
                        }
                    }
                }
            }
            return false;
        }

        public OTGW()
        {
            this.gatewayConfiguration = new GatewayConfiguration();
            this.socketReader = new SocketReader();
        }

        public void Connect(string IPAddress)
        {
            socketReader.Connect(IPAddress);
            this.commandQueue = new ConcurrentQueue<CommandQueueItem>();

            if (this.socketReader.IsConnected())
            {
                this.socketThreadShouldClose = false;
                this.socketThread = new Thread(SocketThread);
                this.socketThread.IsBackground = true;
                this.socketThread.Start();
            }

            //Thread.Sleep(1000); 


            EnqueueCommand("PR=A");
            EnqueueCommand("PR=B");
            EnqueueCommand("PR=C");
            EnqueueCommand("PR=D");
            EnqueueCommand("PR=G");
            EnqueueCommand("PR=I");
            EnqueueCommand("PR=L");
            EnqueueCommand("PR=M");
            EnqueueCommand("PR=O");
            EnqueueCommand("PR=P");
            EnqueueCommand("PR=Q");
            EnqueueCommand("PR=R");
            EnqueueCommand("PR=S");
            EnqueueCommand("PR=T");
            EnqueueCommand("PR=V");
            EnqueueCommand("PR=W");
        }

        public void Disconnect()
        {
            this.socketThreadShouldClose = true;
            while (this.socketThreadHasClosed == false)
            {
                Thread.Sleep(100);
            }
            socketReader.Disconnect();
        }


        public void SocketThread()
        {
            socketThreadHasClosed = false;
            while (socketThreadShouldClose == false)
            {
                string[] lines = socketReader.ReadLines();
                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        Console.WriteLine(line);

                        Parse(line);
                    }
                    Console.WriteLine("-------");

                    if (!commandQueue.IsEmpty)
                    {
                        CommandQueueItem firstItem;
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

                                    TryDequeueCommand(firstItem.command);
                                    //throw new Exception("Command failed!");
                                }
                            }

                        }
                    }
                }
            }
            socketThreadHasClosed = true;
        }

        public class Message
        {
            public enum Direction
            {
                ThermostatToBoiler,
                BoilerToThermostat,
                ThermostatToBoilerModified,
                BoilerToThermostatModified
            }


            private Direction _direction;
            public Direction direction
            {
                get { return _direction; }
                set { _direction = value; }
            }
        }


        public Message Parse(string line)
        {
            Message message = null;

            char[] lineBytes = line.ToUpper().ToCharArray();

            // Parse errors
            if (line.Equals("NG")) Console.WriteLine("OTGW reponse 'NG': No Good");
            else if (line.Equals("SE")) Console.WriteLine("OTGW reponse 'SE': Syntax Error");
            else if (line.Equals("BV")) Console.WriteLine("OTGW reponse 'BV': Bad Value");
            else if (line.Equals("OR")) Console.WriteLine("OTGW reponse 'OR': Out of Range");
            else if (line.Equals("NS")) Console.WriteLine("OTGW reponse 'NS': No Space");
            else if (line.Equals("NF")) Console.WriteLine("OTGW reponse 'NF': Not Found");
            else if (line.Equals("OR")) Console.WriteLine("OTGW reponse 'OR': OverRun");
            else if (line.Length >= 3)
            {
                // parse "PR:" request response
                if (line.Substring(0, 3).Equals("PR:")) {
                    Console.WriteLine("Response to PR command:" + line);
                    TryDequeueCommand("PR");

                    switch (lineBytes[4])
                    {
                        case 'A':
                            this.gatewayConfiguration.version = line.Substring(6);
                            break;
                        case 'B':
                            this.gatewayConfiguration.build = line.Substring(6);
                            break;
                        case 'C':
                            this.gatewayConfiguration.clockSpeed = line.Substring(6);
                            break;
                        case 'D':
                            this.gatewayConfiguration.temperaturSensorFunction = (lineBytes[6] == 'O') ? "Outside Temperature" : "Return water temperature";
                            break;
                        case 'G':
                            this.gatewayConfiguration.gpioFunctionsConfiguration = line.Substring(6);
                            break;
                        case 'I':
                            this.gatewayConfiguration.gpioFunctionsCurrent = line.Substring(6);
                            break;
                        case 'L':
                            this.gatewayConfiguration.ledsFunctionsConfiguration = line.Substring(6);
                            break;
                        case 'M':
                            this.gatewayConfiguration.gatewayMode = (lineBytes[6] == 'G') ? "Gateway" : "Monitor";
                            break;
                        case 'O':
                            this.gatewayConfiguration.setpointOverride = line.Substring(6);
                            break;
                        case 'P':
                            this.gatewayConfiguration.smartPowerModelCurrent = line.Substring(6);
                            break;
                        case 'Q':
                            switch (lineBytes[6])
                            {
                                case 'B':
                                    this.gatewayConfiguration.causeOfLastReset = "Brown out";
                                    break;
                                case 'C':
                                    this.gatewayConfiguration.causeOfLastReset = "By command";
                                    break;
                                case 'E':
                                    this.gatewayConfiguration.causeOfLastReset = "Reset button";
                                    break;
                                case 'L':
                                    this.gatewayConfiguration.causeOfLastReset = "Stuck in loop";
                                    break;
                                case 'O':
                                    this.gatewayConfiguration.causeOfLastReset = "Stack overflow";
                                    break;
                                case 'P':
                                    this.gatewayConfiguration.causeOfLastReset = "Power on";
                                    break;
                                case 'S':
                                    this.gatewayConfiguration.causeOfLastReset = "BREAL on serial interface";
                                    break;
                                case 'U':
                                    this.gatewayConfiguration.causeOfLastReset = "Stack underflow";
                                    break;
                                case 'W':
                                    this.gatewayConfiguration.causeOfLastReset = "Watchdog";
                                    break;
                                default:
                                    this.gatewayConfiguration.causeOfLastReset = "Syntax error";
                                    break;
                            }
                            break;
                        case 'R':
                            this.gatewayConfiguration.remehaDetectionStart = line.Substring(6);
                            break;
                        case 'S':
                            this.gatewayConfiguration.setbackTemperatureConfiguarion = line.Substring(6);
                            break;
                        case 'T':
                            this.gatewayConfiguration.tweaks = line.Substring(6);
                            break;
                        case 'V':
                            this.gatewayConfiguration.referenceVoltage = line.Substring(6);
                            break;
                        case 'W':
                            this.gatewayConfiguration.hotWater = line.Substring(6);
                            break;
                        default:
                            break;
                    }

                } else if (line.Substring(0, 3).Equals("PS:")) {
                    Console.WriteLine("Response to PS command:" + line);
                    TryDequeueCommand("PS");
                } else 
  



                if (line.Length == 9)
                {
                    message = new Message();
                    switch (lineBytes[0])
                    {
                        case 'T':
                            message.direction = Message.Direction.ThermostatToBoiler;
                            break;
                        case 'B':
                            message.direction = Message.Direction.BoilerToThermostat;
                            break;
                        case 'R':
                            message.direction = Message.Direction.ThermostatToBoilerModified;
                            break;
                        case 'A':
                            message.direction = Message.Direction.BoilerToThermostatModified;
                            break;
                        default:
                            Console.WriteLine("Unhandled packet type"); //@@@@ top be fixed
                            message = null;
                            break;
                    }
                }
            }

            return message;
        }


        class SocketReader
        {
            private const int port = 6638;

            private IPAddress ipAddress;
            private Socket socket;


            // constructor
            public SocketReader()
            {
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
                        Console.WriteLine("IP-Address: " + this.ipAddress.ToString());
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
                string[] lines= { };

                Byte[] bytes = new byte[this.socket.ReceiveBufferSize];
                int bytesRecv = this.socket.Receive(bytes);
                if (bytesRecv > 0)
                {
                    msg =  readLinesLeftover + Encoding.ASCII.GetString(bytes, 0, bytesRecv);

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
                        msg = msg.Substring(0, lastIndex+1);
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

                byte[] msg = Encoding.ASCII.GetBytes(line+ "\n\r");
                int byteSent = this.socket.Send(msg);
                if (byteSent != msg.Length)
                {
                    throw new Exception("Message not sent.");
                }
            }
        }


        /*

        class OTGWLogger
        {
            private enum ThreadCloseState
            {
                ThreadShouldRun,
                ThreadShouldClose,
                ThreadHasClosed
            };

            private enum Direction
            {
                ThermostatToBoiler,
                BoilerToThermostat,
                ThermostatToBoilerOriginal,
                BoilerToThermostatOriginal
            }

            private enum MsgType
            {
                ReadData = 0,
                WriteData = 1,
                INVALIDDATA = 2,
                RESERVED = 3,
                ReadAck = 4,
                WRITEACK = 5,
                DATAINVALID = 6,
                UNKNOWNDATAID = 7
            }


            private delegate void HandlerCall(OTGWMessage message, int dataValue);

            private class OTGWMessage
            {
                public string name;
                public MsgType msgType;
                public int dataID;
                public Direction direction;
                public HandlerCall handler;
                public int handlerParam;
                public float currentValue;

                public OTGWMessage(string name, MsgType msgType, int dataID, Direction direction, HandlerCall handler, int handlerParam)
                {
                    this.name = name;
                    this.msgType = msgType;
                    this.dataID = dataID;
                    this.direction = direction;
                    this.handler = handler;
                    this.handlerParam = handlerParam;
                    this.currentValue = 0;
                }
            }

            private OTGWMessage[] message;

            public string ipAddress;



            private Thread logThread;
            private volatile ThreadCloseState logThreadWantToClose;


            public int GetElementCount()
            {
                return this.message.Length;
            }

            public string GetElementName(int i)
            {
                return this.message[i].name;
            }

            public float GetElementValue(int i)
            {
                return this.message[i].currentValue;
            }


            public OTGWLogger()
            {
                this.message = new OTGWMessage[] {
            new OTGWMessage("Central heating enable",   MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 8),
            new OTGWMessage("Tap water enable",         MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 9),
            new OTGWMessage("Cooling enable",           MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 10),
            new OTGWMessage("OTC active",               MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 11),
            new OTGWMessage("CH2 enable",               MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 12),
            new OTGWMessage("Fault indication",         MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 0),
            new OTGWMessage("Central heating mode",     MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 1),
            new OTGWMessage("Tap water mode",           MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 2),
            new OTGWMessage("Flame status",             MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 3),
            new OTGWMessage("Cooling status",           MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 4),
            new OTGWMessage("CH2 mode",                 MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 5),
            new OTGWMessage("Diagnostic indication",    MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 6),
            new OTGWMessage("Control setpoint",         MsgType.WriteData, 1, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Control setpoint original",MsgType.WriteData, 1, Direction.ThermostatToBoilerOriginal, Handlerf88, 0),
            new OTGWMessage("Master memberID",          MsgType.WriteData, 2, Direction.ThermostatToBoiler, Handleru8L, 0),
            new OTGWMessage("Tap water present",        MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 8),
            new OTGWMessage("Control type",             MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 9),
            new OTGWMessage("Cooling config",           MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 10),
            new OTGWMessage("Tap water config",         MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 11),
            new OTGWMessage("Master low-off&pump control", MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 12),
            new OTGWMessage("CH2 present",              MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 13),
            new OTGWMessage("Slave memberID",           MsgType.ReadAck,   3, Direction.BoilerToThermostat, Handleru8L, 0),
            new OTGWMessage("Service request",          MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 8),
            new OTGWMessage("Lockout reset",            MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 9),
            new OTGWMessage("Low water pressure",       MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 10),
            new OTGWMessage("Gas/flame fault",          MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 11),
            new OTGWMessage("Air pressure fault",       MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 12),
            new OTGWMessage("Water over-temp",          MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 13),
            new OTGWMessage("OEM-specific fault code",  MsgType.ReadAck,   5, Direction.BoilerToThermostat, Handleru8L, 0),
            new OTGWMessage("Control setpoint 2",       MsgType.WriteData, 8, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Room setpoint",            MsgType.WriteData, 16, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Relative modulation level",MsgType.ReadAck,   17, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Water pressure CH circuit", MsgType.ReadAck,   18, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Water flow rate DHW circuit", MsgType.ReadAck,   19, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Time and Day",             MsgType.ReadAck,   20, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Time and Day",             MsgType.WriteData, 20, Direction.ThermostatToBoiler, Handleru16, 0),
            new OTGWMessage("Date",                     MsgType.ReadAck,   21, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Date",                     MsgType.WriteData, 21, Direction.ThermostatToBoiler, Handleru16, 0),
            new OTGWMessage("Year",                     MsgType.ReadAck,   22, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Year",                     MsgType.WriteData, 22, Direction.ThermostatToBoiler, Handleru16, 0),
            new OTGWMessage("Room setpoint 2",          MsgType.WriteData, 23, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Room temperature",         MsgType.WriteData, 24, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Boiler water temperture",  MsgType.ReadAck,   25, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Tap water temperture",     MsgType.ReadAck,   26, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Outside temperture",       MsgType.ReadAck,   27, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Return water temperture",  MsgType.ReadAck,   28, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Solar storage temperture", MsgType.ReadAck,   29, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Solar collector temperture", MsgType.ReadAck,   30, Direction.BoilerToThermostat, Handlers16, 0),
            new OTGWMessage("Flow temperature CH2",     MsgType.ReadAck,   31, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Tap water temperature 2",  MsgType.ReadAck,   32, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Exhaust temperture",       MsgType.ReadAck,   33, Direction.BoilerToThermostat, Handlers16, 0),
            new OTGWMessage("OEM-specifc diagnostic code", MsgType.ReadAck,115, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Burner starts",            MsgType.ReadAck,   116, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Central heating pump starts", MsgType.ReadAck,   117, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Tap water valve starts",   MsgType.ReadAck,   118, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Tap water burner starts",  MsgType.ReadAck,   119, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Burner operation hours",   MsgType.ReadAck,   120, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Central heating pump hours", MsgType.ReadAck,   121, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Tap water valve hours",    MsgType.ReadAck,   122, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Tap water burner hours",   MsgType.ReadAck,   123, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("OpenTherm version master", MsgType.ReadAck,   124, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("OpenTherm version slave",  MsgType.ReadAck,   125, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Product type master",      MsgType.ReadAck,   126, Direction.BoilerToThermostat, Handleru8H, 0),
            new OTGWMessage("Product version master",   MsgType.WriteData,  126, Direction.ThermostatToBoiler, Handleru8L, 0),
            new OTGWMessage("Product type slave",       MsgType.ReadAck,   127, Direction.BoilerToThermostat, Handleru8H, 0),
            new OTGWMessage("Product version slave",    MsgType.ReadAck,   127, Direction.BoilerToThermostat, Handleru8L, 0),
            };
            }


            public void SetSetpoint(int setpoint)
            {
                if (streamWriter != null)
                {
                    try
                    {

                        streamWriter.WriteLine("CS=" + setpoint.ToString());
                        streamWriter.Flush();
                    }
                    catch
                    {
                        Console.WriteLine("CS=I/O error"); //@@@@
                    }
                    Console.WriteLine("CS=" + setpoint.ToString()); //@@@@
                }
            }

            private void HandlerFlag16(OTGWMessage message, int dataValue)
            {
                message.currentValue = (float)((dataValue >> message.handlerParam) & 1);
            }

            private void Handlerf88(OTGWMessage message, int dataValue)
            {
                message.currentValue = ((float)(dataValue)) / 256;
            }

            private void Handleru8L(OTGWMessage message, int dataValue)
            {
                message.currentValue = (float)(dataValue & 0xff);
            }

            private void Handleru8H(OTGWMessage message, int dataValue)
            {
                message.currentValue = (float)((dataValue >> 8) & 0xff);
            }

            private void Handleru16(OTGWMessage message, int dataValue)
            {
                message.currentValue = (float)(dataValue);
            }

            private void Handlers16(OTGWMessage message, int dataValue)
            {
                message.currentValue = (float)(dataValue);
                if (message.currentValue > 32767) message.currentValue -= 65536;
            }

            private void LogThread()
            {
                int counter = 0;

                while (this.logThreadWantToClose == ThreadCloseState.ThreadShouldRun)
                {
                    if (counter == 5)
                    {
                        string line;

                        // try-catch needed to catch timeout
                        try
                        {
                            line = streamReader.ReadLine();
                            Console.WriteLine(line);
                        }
                        catch
                        {
                            line = "";
                        }
                        if ((line.Length == 9) && (!line.Substring(0, 3).Equals("CS:")))
                        {
                            char[] lineBytes = line.ToUpper().ToCharArray();
                            char source = lineBytes[0];
                            int msgType = (Convert.ToInt32(line.Substring(1, 2), 16) & 0x70) >> 4;
                            int dataid = Convert.ToInt32(line.Substring(3, 2), 16);
                            int datavalue = Convert.ToInt32(line.Substring(5, 4), 16);
                            if ((source == 'A') || (source == 'R') || (source == 'B') || (source == 'T'))
                            {
                                foreach (OTGWMessage element in this.message)
                                {
                                    if (((element.direction == Direction.BoilerToThermostat) && (source == 'B')) ||
                                        ((element.direction == Direction.ThermostatToBoiler) && (source == 'T')) ||
                                        ((element.direction == Direction.BoilerToThermostatOriginal) && (source == 'R')) ||
                                        ((element.direction == Direction.ThermostatToBoilerOriginal) && (source == 'A')))
                                    {
                                        if (element.msgType == (MsgType)msgType)
                                        {
                                            if (element.dataID == dataid)
                                            { // we have found a match
                                                element.handler(element, datavalue);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        counter = 0;
                    }
                    counter++;
                    Thread.Sleep(100);
                }
                this.logThreadWantToClose = ThreadCloseState.ThreadHasClosed;
            }
        }
        */
    }
}
