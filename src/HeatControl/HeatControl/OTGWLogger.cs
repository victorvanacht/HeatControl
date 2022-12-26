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
        public struct intValueName
        {
            public int value;
            public string name;
        }
        public struct boolValueName
        {
            public bool value;
            public string name;
        }
        public struct floatValueName
        {
            public float value;
            public string name;
        }
        public struct stringValueName
        {
            public string value;
            public string name;
        }

        public class GatewayConfiguration
        {
            public stringValueName version;
            public stringValueName build;
            public stringValueName clockSpeed;
            public stringValueName temperaturSensorFunction;
            public stringValueName gpioFunctionsConfiguration;
            public stringValueName gpioState;
            public stringValueName ledFunctionsConfiguration;
            public stringValueName gatewayMode;
            public stringValueName setpointOverride;
            public stringValueName smartPowerModel;
            public stringValueName causeOfLastReset;
            public stringValueName remehaDetectionState;
            public stringValueName setbackTemperatureConfiguarion;
            public stringValueName tweaks;
            public stringValueName referenceVoltage;
            public stringValueName hotWater;

            public GatewayConfiguration()
            {
                this.version.name = "OTGW Version";
                this.build.name = "OTGW Build";
                this.clockSpeed.name = "Clock speed";
                this.temperaturSensorFunction.name = "DS18x20 temperature function";
                this.gpioFunctionsConfiguration.name = "GPIO function configuation";
                this.gpioState.name = "GPIO state";
                this.ledFunctionsConfiguration.name = "LED fucntion configuration";
                this.gatewayMode.name = "Gateway mode";
                this.setpointOverride.name = "Setpoint override";
                this.smartPowerModel.name = "Smart-Power mode";
                this.causeOfLastReset.name = "Cause of last reset";
                this.remehaDetectionState.name = "Remeha thermostat detection state";
                this.setbackTemperatureConfiguarion.name = "Setback temperature configuration";
                this.tweaks.name = "Tweaks";
                this.referenceVoltage.name = "Reference voltage";
                this.hotWater.name = "Domestic hot water";

            }

        }
        public GatewayConfiguration gatewayConfiguration;

        public class GatewayStatus
        {
            public boolValueName centralHeatingEnable;

            public GatewayStatus()
            {
                this.centralHeatingEnable.name = "Central heating enable";
            }
        }
        public GatewayStatus gatewayStatus;

        private SocketReader socketReader;
        private Thread socketThread;
        private volatile bool socketThreadShouldClose;
        private volatile bool socketThreadHasClosed;

        private CommandQueue commandQueue;



        public class CommandQueue
        {
            public class CommandQueueItem
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
            private ConcurrentQueue<CommandQueueItem> queue;

            public CommandQueue()
            {
                this.queue = new ConcurrentQueue<CommandQueueItem>();
            }


            public void EnqueueCommand(string command)
            {
                CommandQueueItem item = new CommandQueueItem(command);
                queue.Enqueue(item);
            }

            public bool TryDequeueCommand(string command)
            {
                if (!queue.IsEmpty)
                {
                    CommandQueueItem firstItem;
                    if (queue.TryPeek(out firstItem))
                    {
                        if ((command.Length >= 2) && (firstItem.command.Length >= 2))
                        {
                            if (command.Substring(0, 2).ToUpper().Equals(firstItem.command.Substring(0, 2).ToUpper()))
                            {
                                return queue.TryDequeue(out firstItem);
                            }
                        }
                    }
                }
                return false;
            }

            public bool IsEmpty()
            {
                return this.queue.IsEmpty;
            }

            public bool TryDequeue(out CommandQueueItem result)
            {
                return this.queue.TryDequeue(out result);
            }

            public bool TryPeek(out CommandQueueItem result)
            {
                return this.queue.TryPeek(out result);
            }
        }


        /*
            new OTGWMessage("Central heating enable", MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 8),
            new OTGWMessage("Tap water enable", MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 9),
            new OTGWMessage("Cooling enable", MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 10),
            new OTGWMessage("OTC active", MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 11),
            new OTGWMessage("CH2 enable", MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 12),
            new OTGWMessage("Fault indication", MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 0),
            new OTGWMessage("Central heating mode", MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 1),
            new OTGWMessage("Tap water mode", MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 2),
            new OTGWMessage("Flame status", MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 3),
            new OTGWMessage("Cooling status", MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 4),
            new OTGWMessage("CH2 mode", MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 5),
            new OTGWMessage("Diagnostic indication", MsgType.ReadAck,  0, Direction.BoilerToThermostat, HandlerFlag16, 6),
            new OTGWMessage("Control setpoint", MsgType.WriteData, 1, Direction.ThermostatToBoiler, Handlerf88, 0),

            new OTGWMessage("Control setpoint original", MsgType.WriteData, 1, Direction.ThermostatToBoilerOriginal, Handlerf88, 0),

            new OTGWMessage("Master memberID", MsgType.WriteData, 2, Direction.ThermostatToBoiler, Handleru8L, 0),
            new OTGWMessage("Tap water present", MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 8),
            new OTGWMessage("Control type", MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 9),
            new OTGWMessage("Cooling config", MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 10),
            new OTGWMessage("Tap water config", MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 11),
            new OTGWMessage("Master low-off&pump control", MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 12),
            new OTGWMessage("CH2 present", MsgType.ReadAck,   3, Direction.BoilerToThermostat, HandlerFlag16, 13),
            new OTGWMessage("Slave memberID", MsgType.ReadAck,   3, Direction.BoilerToThermostat, Handleru8L, 0),
            new OTGWMessage("Service request", MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 8),
            new OTGWMessage("Lockout reset", MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 9),
            new OTGWMessage("Low water pressure", MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 10),
            new OTGWMessage("Gas/flame fault", MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 11),
            new OTGWMessage("Air pressure fault", MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 12),
            new OTGWMessage("Water over-temp", MsgType.ReadAck,   5, Direction.BoilerToThermostat, HandlerFlag16, 13),
            new OTGWMessage("OEM-specific fault code", MsgType.ReadAck,   5, Direction.BoilerToThermostat, Handleru8L, 0),
            new OTGWMessage("Control setpoint 2", MsgType.WriteData, 8, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Room setpoint", MsgType.WriteData, 16, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Relative modulation level", MsgType.ReadAck,   17, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Water pressure CH circuit", MsgType.ReadAck,   18, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Water flow rate DHW circuit", MsgType.ReadAck,   19, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Time and Day", MsgType.ReadAck,   20, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Time and Day", MsgType.WriteData, 20, Direction.ThermostatToBoiler, Handleru16, 0),
            new OTGWMessage("Date", MsgType.ReadAck,   21, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Date", MsgType.WriteData, 21, Direction.ThermostatToBoiler, Handleru16, 0),
            new OTGWMessage("Year", MsgType.ReadAck,   22, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Year", MsgType.WriteData, 22, Direction.ThermostatToBoiler, Handleru16, 0),
            new OTGWMessage("Room setpoint 2", MsgType.WriteData, 23, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Room temperature", MsgType.WriteData, 24, Direction.ThermostatToBoiler, Handlerf88, 0),
            new OTGWMessage("Boiler water temperture", MsgType.ReadAck,   25, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Tap water temperture", MsgType.ReadAck,   26, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Outside temperture", MsgType.ReadAck,   27, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Return water temperture", MsgType.ReadAck,   28, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Solar storage temperture", MsgType.ReadAck,   29, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Solar collector temperture", MsgType.ReadAck,   30, Direction.BoilerToThermostat, Handlers16, 0),
            new OTGWMessage("Flow temperature CH2", MsgType.ReadAck,   31, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Tap water temperature 2", MsgType.ReadAck,   32, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Exhaust temperture", MsgType.ReadAck,   33, Direction.BoilerToThermostat, Handlers16, 0),
            new OTGWMessage("OEM-specifc diagnostic code", MsgType.ReadAck,115, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Burner starts", MsgType.ReadAck,   116, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Central heating pump starts", MsgType.ReadAck,   117, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Tap water valve starts", MsgType.ReadAck,   118, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Tap water burner starts", MsgType.ReadAck,   119, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Burner operation hours", MsgType.ReadAck,   120, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Central heating pump hours", MsgType.ReadAck,   121, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Tap water valve hours", MsgType.ReadAck,   122, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("Tap water burner hours", MsgType.ReadAck,   123, Direction.BoilerToThermostat, Handleru16, 0),
            new OTGWMessage("OpenTherm version master", MsgType.ReadAck,   124, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("OpenTherm version slave", MsgType.ReadAck,   125, Direction.BoilerToThermostat, Handlerf88, 0),
            new OTGWMessage("Product type master", MsgType.ReadAck,   126, Direction.BoilerToThermostat, Handleru8H, 0),
            new OTGWMessage("Product version master", MsgType.WriteData,  126, Direction.ThermostatToBoiler, Handleru8L, 0),
            new OTGWMessage("Product type slave", MsgType.ReadAck,   127, Direction.BoilerToThermostat, Handleru8H, 0),
            new OTGWMessage("Product version slave", MsgType.ReadAck,   127, Direction.BoilerToThermostat, Handleru8L, 0),
            */


        private Parser parser;


        public OTGW()
        {
            this.gatewayConfiguration = new GatewayConfiguration();
            this.socketReader = new SocketReader();
            this.commandQueue = new CommandQueue();
            this.parser = new Parser(ref this.gatewayConfiguration, ref this.gatewayStatus, ref this.commandQueue);
            

        }

        public void Connect(string hostName)
        {
            socketReader.Connect(hostName);

            if (this.socketReader.IsConnected())
            {
                this.socketThreadShouldClose = false;
                this.socketThread = new Thread(SocketThread);
                this.socketThread.IsBackground = true;
                this.socketThread.Start();
            }

            Thread.Sleep(1000);

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
                        Console.WriteLine(DateTime.Now.ToString() + " R:" +line);
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
            }
            socketThreadHasClosed = true;
        }

        private class Parser
        {
            private GatewayConfiguration gatewayConfiguration;
            private GatewayStatus gatewayStatus;
            private CommandQueue commandQueue;
            private Dictionary<string, ParsersBase> decodeMessages;

            public class Message
            {
                public enum Direction
                {
                    ThermostatToBoiler,
                    BoilerToThermostat,
                    ThermostatToBoilerModified,
                    BoilerToThermostatModified
                }

                public enum Type
                {
                    M2SReadData = 0,
                    M2SWriteData = 1,
                    M2SInvalidData = 2,
                    S2MReadAck = 4,
                    S2MWriteAck = 5,
                    S2MInavlidData = 6,
                    S2MUnknownData = 7
                }

                private Direction _direction;
                public Direction direction
                {
                    get { return _direction; }
                    set { _direction = value; }
                }

                private Type _type;
                public Type type
                {
                    get { return _type; }
                    set { _type = value; }
                }

                public int dataID;
                public int dataValue;

                public string GenerateKey()
                {
                    return GenerateKey(this.dataID, this.direction, this.type);
                }

                public static string GenerateKey(int dataID, Direction direction, Type type)
                {
                    return dataID.ToString() + direction.ToString() + type.ToString();
                }
            }

            public Parser(ref GatewayConfiguration configuration, ref GatewayStatus status, ref CommandQueue commandQueue)
            {
                this.gatewayConfiguration = configuration;
                this.gatewayStatus = status;
                this.commandQueue = commandQueue;

                /*
                this.decodeMessages = new Dictionary<string, ParsersBase>()
                [Message.GenerateKey(0, Message.Direction.ThermostatToBoiler, Message.Type.M2SReadData)] = new ParseDispatch { name = "Central heating enable", parser = new Flags16()},
                //new OTGWMessage("Central heating enable", MsgType.ReadData, 0, Direction.ThermostatToBoiler, HandlerFlag16, 8),


                ["1"] = new ParseDispatch { name = "Control setpoint" },
                ["2"] = new ParseDispatch { name = "Master memberID"}

            };

*/
            }



            abstract private class ParsersBase
            {
                abstract public void Parse(Message message);
            }

            private class Flags16 : ParsersBase
            {
                public Flags16()
                {
                    Console.WriteLine("This is the contructor of Flasg16");
                }

                override public void Parse(Message message)
                {
                    Console.WriteLine("Parse16");
                }
            }

            private class Flags8 : ParsersBase
            {
                public Flags8()
                {
                    Console.WriteLine("This is the contructor of Flasg8");
                }


                override public void Parse(Message message)
                {
                    Console.WriteLine("Parse8");
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
                    if (line.Substring(0, 3).Equals("PR:"))
                    {
                        commandQueue.TryDequeueCommand("PR");

                        switch (lineBytes[4])
                        {
                            case 'A':
                                this.gatewayConfiguration.version.value = line.Substring(6);
                                break;
                            case 'B':
                                this.gatewayConfiguration.build.value = line.Substring(6);
                                break;
                            case 'C':
                                this.gatewayConfiguration.clockSpeed.value = line.Substring(6);
                                break;
                            case 'D':
                                this.gatewayConfiguration.temperaturSensorFunction.value = (lineBytes[6] == 'O') ? "Outside Temperature" : "Return water temperature";
                                break;
                            case 'G':
                                this.gatewayConfiguration.gpioFunctionsConfiguration.value = line.Substring(6);
                                break;
                            case 'I':
                                this.gatewayConfiguration.gpioState.value = line.Substring(6);
                                break;
                            case 'L':
                                this.gatewayConfiguration.ledFunctionsConfiguration.value = line.Substring(6);
                                break;
                            case 'M':
                                this.gatewayConfiguration.gatewayMode.value = (lineBytes[6] == 'G') ? "Gateway" : "Monitor";
                                break;
                            case 'O':
                                this.gatewayConfiguration.setpointOverride.value = line.Substring(6);
                                break;
                            case 'P':
                                this.gatewayConfiguration.smartPowerModel.value = line.Substring(6);
                                break;
                            case 'Q':
                                switch (lineBytes[6])
                                {
                                    case 'B':
                                        this.gatewayConfiguration.causeOfLastReset.value = "Brown out";
                                        break;
                                    case 'C':
                                        this.gatewayConfiguration.causeOfLastReset.value = "By command";
                                        break;
                                    case 'E':
                                        this.gatewayConfiguration.causeOfLastReset.value = "Reset button";
                                        break;
                                    case 'L':
                                        this.gatewayConfiguration.causeOfLastReset.value = "Stuck in loop";
                                        break;
                                    case 'O':
                                        this.gatewayConfiguration.causeOfLastReset.value = "Stack overflow";
                                        break;
                                    case 'P':
                                        this.gatewayConfiguration.causeOfLastReset.value = "Power on";
                                        break;
                                    case 'S':
                                        this.gatewayConfiguration.causeOfLastReset.value = "BREAL on serial interface";
                                        break;
                                    case 'U':
                                        this.gatewayConfiguration.causeOfLastReset.value = "Stack underflow";
                                        break;
                                    case 'W':
                                        this.gatewayConfiguration.causeOfLastReset.value = "Watchdog";
                                        break;
                                    default:
                                        this.gatewayConfiguration.causeOfLastReset.value = "Syntax error";
                                        break;
                                }
                                break;
                            case 'R':
                                this.gatewayConfiguration.remehaDetectionState.value = line.Substring(6);
                                break;
                            case 'S':
                                this.gatewayConfiguration.setbackTemperatureConfiguarion.value = line.Substring(6);
                                break;
                            case 'T':
                                this.gatewayConfiguration.tweaks.value = line.Substring(6);
                                break;
                            case 'V':
                                this.gatewayConfiguration.referenceVoltage.value = line.Substring(6);
                                break;
                            case 'W':
                                this.gatewayConfiguration.hotWater.value = line.Substring(6);
                                break;
                            default:
                                break;
                        }

                    }
                    else if (line.Substring(0, 3).Equals("PS:"))
                    { //@@@@@ this needs to be modified be
                        commandQueue.TryDequeueCommand("PS");
                    }
                    else

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
                        if (message != null)
                        {
                            message.type = (Message.Type)((Convert.ToInt32(line.Substring(1, 2), 16) & 0x70) >> 4);
                            message.dataID = Convert.ToInt32(line.Substring(3, 2), 16);
                            message.dataValue = Convert.ToInt32(line.Substring(5, 4), 16);

                            string key = message.GenerateKey();
                            /*
                            if (decodeMessages.ContainsKey(key))
                            {
                                ParsersBase handler = decodeMessages[key];
                                handler.Parse(message);

                            }
                            */
                        }
                    }
                }

                return message;
            }
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
                Console.WriteLine(DateTime.Now.ToString() + " T:" + line);

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
