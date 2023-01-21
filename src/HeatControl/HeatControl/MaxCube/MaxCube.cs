using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static HeatControl.MaxCubeLogger;
using static HeatControl.OTGW;

namespace HeatControl
{
    partial class MaxCubeLogger
    { 
        public partial class MaxCube
        {
            public enum DeviceType
            {
                Cube = 0,                
                HeatingThermostat = 1,
                HeatingThermostatTODO = 2,
                WallThermostat = 3,
                EcoSwitch = 5,
            };


            public class Room
            {
                public string name;
                public int rfAddress;
                public int roomID;
                public float configuredTemperature;
                public float actualTemperature;

                public List<DeviceBase> devices;
                public Room(string name, int rfAddress, int roomID)
                { 
                    this.name = name;
                    this.rfAddress = rfAddress;
                    this.roomID = roomID;

                    this.devices = new List<DeviceBase>();
                }
            }

            public class DeviceBase
            {
                public DeviceType type;
                public string name;
                public string serialNumber;
                public int rfAddress;
                public Room room;

                public class ProgramEntry
                {
                    float temperature;
                    int hours;
                    int minutes;

                    public ProgramEntry(float temperature, int hours, int minutes)
                    {
                        this.temperature = temperature;
                        this.hours = hours;
                        this.minutes = minutes;
                    }
                }

                public DeviceBase(DeviceType type, string name, string serialNumber, int rfAddress, Room room)
                {
                    this.type= type;
                    this.name = name;
                    this.serialNumber = serialNumber;
                    this.rfAddress = rfAddress;
                    this.room = room;
                }

                static public DeviceBase CreateFromTypeID(DeviceType type, string name, string serialNumber, int rfAddress, Room room)
                {
                    switch (type)
                    {
                        case DeviceType.HeatingThermostat:
                            return new DeviceHeatingThermostat(name, serialNumber, rfAddress, room);
                        case DeviceType.HeatingThermostatTODO:
                            DeviceBase r = new DeviceHeatingThermostat(name, serialNumber, rfAddress, room);
                            r.type = DeviceType.HeatingThermostatTODO; 
                            return r;
                        case DeviceType.WallThermostat :
                            return new DeviceWallThermostat(name, serialNumber, rfAddress, room);
                        case DeviceType.EcoSwitch:
                            return new DeviceEcoSwitch(name, serialNumber, rfAddress, room);
                        default:
                            throw new Exception("This should not happen");
                            return null;
                    }
                }
            }

            public class DeviceWallThermostat : DeviceBase
            {
                public float comfortTemperature;
                public float ecoTemperature;
                public float maxSetpointTemperature;
                public float minSetpointTemperature;
                public float configuredTemperature;
                public float actualTemperature;

                public List<List<ProgramEntry>> program;

                public DeviceWallThermostat(string name, string serialNumber, int rfAddress, Room room) : 
                    base(DeviceType.WallThermostat, name, serialNumber, rfAddress, room)
                {
                    this.comfortTemperature = -1;
                    this.ecoTemperature = -1;
                    this.maxSetpointTemperature = -1;
                    this.minSetpointTemperature = -1;
                    this.program = new List<List<ProgramEntry>>(7*13);
                    for (int day = 0; day < 7; day++)
                    {
                        this.program.Add(new List<ProgramEntry>());
                        for (int i = 0; i < 13; i++)
                        {
                            this.program[day].Add(new ProgramEntry(-1, -1, -1));
                        }
                    }
                }
            }

            public class DeviceHeatingThermostat : DeviceBase
            {
                public float comfortTemperature;
                public float ecoTemperature;
                public float maxSetpointTemperature;
                public float minSetpointTemperature;
                public float temperatureOffset;
                public float windowOpenTemperature;
                public int windowOpenDuration; // in minutes
                public int boostDuration; // in minutes
                public int boostValvePercentage;
                public int decalcificationDay;
                public int decalcificationHours;
                public float maxValveSettingPercent;
                public float valveOffsetPercent;
                public int valvePosition;
                public float configuredTemperature;
                public List<List<ProgramEntry>> program;

                public DeviceHeatingThermostat(string name, string serialNumber, int rfAddress, Room room) :
                    base(DeviceType.HeatingThermostat, name, serialNumber, rfAddress, room)
                {
                    this.comfortTemperature = -1;
                    this.ecoTemperature = -1;
                    this.maxSetpointTemperature = -1;
                    this.minSetpointTemperature = -1;
                    this.temperatureOffset = -1;
                    this.windowOpenTemperature = -1;
                    this.windowOpenDuration = -1;
                    this.boostDuration = -1;
                    this.boostValvePercentage = -1;
                    this.decalcificationDay = -1;
                    this.decalcificationDay = -1;
                    this.maxValveSettingPercent= -1;
                    this.valveOffsetPercent = -1;
                    this.program = new List<List<ProgramEntry>>(7 * 13);
                    for (int day = 0; day < 7; day++)
                    {
                        this.program.Add(new List<ProgramEntry>());
                        for (int i = 0; i < 13; i++)
                        {
                            this.program[day].Add(new ProgramEntry(-1, -1, -1));
                        }
                    }
                }
            }

            public class DeviceEcoSwitch : DeviceBase
            {
                public DeviceEcoSwitch(string name, string serialNumber, int rfAddress, Room room) :
                    base(DeviceType.EcoSwitch, name, serialNumber, rfAddress, room)
                {
                }
            }

            public class DeviceMaxCube : DeviceBase
            {
                public string version;
                public int dutyCycle;
                public int freeMemorySlots;
                public DateTime dateTime;
                public bool portalEnabled;
                public string portalURL;
                public int pushButtonUpConfig;
                public int pushButtonDownConfig;


                public DeviceMaxCube(string name, string serialNumber, int rfAddress, Room room) :
                    base(DeviceType.Cube, name, serialNumber, rfAddress, room)
                {
                }
            }




            public IPAddress iPAddress;
            public DeviceMaxCube deviceMaxCube;

            public SortedDictionary<int, Room> rooms;
            public Dictionary<int, DeviceBase> deviceLookup;

            private SocketReader socketReader;
            private Parser parser;
            private MaxCubeLogger maxCubeLogger;

            public MaxCube(MaxCubeLogger maxCubeLogger, IPAddress iPAddress, string name, string serial, int RFAddress, string version)
            {
                this.deviceLookup = new Dictionary<int, DeviceBase>();
                this.rooms = new SortedDictionary<int, Room>();
                this.rooms.Add(0, new Room("House", 0, 0));

                this.deviceMaxCube = new DeviceMaxCube(name, serial, RFAddress, this.rooms[0]);
                //this.deviceLookup.Add(RFAddress, this.deviceMaxCube); because we dont know the RFaddress at this point in time, we delay this operation, and do it in the implementation of the "H" parser, where we have all information that we need.

                this.maxCubeLogger = maxCubeLogger;
                this.iPAddress = iPAddress;
                this.deviceMaxCube .version = version;

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

            }

            public void Disconnect()
            {
                this.socketThreadShouldClose = true;
                this.socketThread.Join();
                this.socketReader.Disconnect();
            }

            public bool IsConnected()
            {
                return this.socketReader.IsConnected();
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

            public static int GetRfAddres(byte[] data)
            {
                return GetRfAddress(data, 0);
            }

            public static int GetRfAddress(byte[] data, int offset)
            {
                return (data[offset] << 16) + (data[offset + 1] << 8) + data[offset + 2];
            }
        }
    }
}
