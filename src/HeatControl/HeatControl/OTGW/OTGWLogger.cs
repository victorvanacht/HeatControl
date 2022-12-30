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
        public class IntValueName
        {
            public int value;
            public string name;

            public IntValueName(string name)
            {
                this.value = -1; // uninitialzed indicator
                this.name = name;
            }
        }
        public class BoolValueName
        {
            public bool value;
            public string name;

            public BoolValueName(string name)
            {
                this.value = false; // uninitialzed indicator????
                this.name = name;
            }


        }
        public class FloatValueName
        {
            public float value;
            public string name;

            public FloatValueName(string name)
            {
                this.value = -1; // uninitialzed indicator
                this.name = name;
            }

        }
        public class StringValueName
        {
            public string value;
            public string name;

            public StringValueName(string name)
            {
                this.value = ""; // uninitialzed indicator
                this.name = name;
            }

        }

        public class GatewayConfiguration
        {
            public StringValueName version;
            public StringValueName build;
            public StringValueName clockSpeed;
            public StringValueName temperaturSensorFunction;
            public StringValueName gpioFunctionsConfiguration;
            public StringValueName gpioState;
            public StringValueName ledFunctionsConfiguration;
            public StringValueName gatewayMode;
            public StringValueName setpointOverride;
            public StringValueName smartPowerModel;
            public StringValueName causeOfLastReset;
            public StringValueName remehaDetectionState;
            public StringValueName setbackTemperatureConfiguarion;
            public StringValueName tweaks;
            public StringValueName referenceVoltage;
            public StringValueName hotWater;

            public GatewayConfiguration()
            {
                this.version = new StringValueName("OTGW Version");
                this.build = new StringValueName("OTGW Build");
                this.clockSpeed = new StringValueName("Clock speed");
                this.temperaturSensorFunction = new StringValueName("DS18x20 temperature function");
                this.gpioFunctionsConfiguration = new StringValueName("GPIO function configuation");
                this.gpioState = new StringValueName("GPIO state");
                this.ledFunctionsConfiguration = new StringValueName("LED fucntion configuration");
                this.gatewayMode = new StringValueName("Gateway mode");
                this.setpointOverride = new StringValueName("Setpoint override");
                this.smartPowerModel = new StringValueName("Smart-Power mode");
                this.causeOfLastReset = new StringValueName("Cause of last reset");
                this.remehaDetectionState = new StringValueName("Remeha thermostat detection state");
                this.setbackTemperatureConfiguarion = new StringValueName("Setback temperature configuration");
                this.tweaks = new StringValueName("Tweaks");
                this.referenceVoltage = new StringValueName("Reference voltage");
                this.hotWater = new StringValueName("Domestic hot water");

            }

        }
        public GatewayConfiguration gatewayConfiguration;
        
        public class GatewayStatus
        {
            public BoolValueName centralHeatingEnable;
            public BoolValueName tapWaterEnable;
            public BoolValueName coolingEnable;
            public BoolValueName OTCActive;
            public BoolValueName CH2Enable;
            public BoolValueName faultIndication;
            public BoolValueName centralHeatingMode;
            public BoolValueName tapWaterMode;
            public BoolValueName flameStatus;
            public BoolValueName coolingStatus;
            public BoolValueName CH2Mode;
            public BoolValueName diagnosticIndication;

            public FloatValueName controlSetPoint;
            public FloatValueName controlSetPointModified;
            public IntValueName masterMemberID;
            public IntValueName slaveMemberID;

            public BoolValueName tapWaterPresent;
            public BoolValueName controlType;
            public BoolValueName coolingConfiguration;
            public BoolValueName tapWaterConfiguration;
            public BoolValueName masterLowOffPumpControl;
            public BoolValueName CH2Present;

            public BoolValueName serviceRequest;
            public BoolValueName lockoutReset;
            public BoolValueName lowWaterPressure;
            public BoolValueName gasFlamFault;
            public BoolValueName airPressureFault;
            public BoolValueName waterOverTemp;
            public IntValueName OEMFaultCode;

            public FloatValueName controlSetPoint2;
            public FloatValueName roomSetPoint;
            public FloatValueName relativeModulationLevel;
            public FloatValueName waterPressureCHCircuit;
            public FloatValueName waterFlowRateTap;

            public IntValueName timeAndDay;
            public IntValueName date;
            public IntValueName year;
            public FloatValueName roomSetpoint2;
            public FloatValueName roomTemperature;
            public FloatValueName boilerWaterTemperature;
            public FloatValueName tapWaterTemperature;
            public FloatValueName outsideTemperature;
            public FloatValueName returnWaterTemperature;
            public FloatValueName solarStorageTemperature;
            public IntValueName solarCollectorTemperature;
            public FloatValueName flowTemperatureCH2;
            public FloatValueName tapWaterTemperature2;
            public IntValueName exhaustTemperature;
            
            public IntValueName OEMDiagnosticCode;
            public IntValueName burnerStarts;
            public IntValueName pumpStarts;
            public IntValueName tapWaterValveStarts;
            public IntValueName tapWaterBurnerStarts;
            public IntValueName burnerOperatingHours;
            public IntValueName pumpOperatingHours;
            public IntValueName tapWaterValveHours;
            public IntValueName tapWaterBurnerHours;

            public FloatValueName openthermVersionMaster;
            public FloatValueName openthermVersionSlave;
            public IntValueName productTypeMaster;
            public IntValueName productVersionMaster;
            public IntValueName productTypeSlave;
            public IntValueName productVersionSlave;


            public GatewayStatus()
            {
                this.centralHeatingEnable= new BoolValueName("Central heating enable");
                this.tapWaterEnable = new BoolValueName("Tap water enable");
                this.coolingEnable = new BoolValueName("Cooling enable");
                this.OTCActive = new BoolValueName("OTC active");
                this.CH2Enable = new BoolValueName("CH2 enable");
                this.faultIndication = new BoolValueName("Fault indication");
                this.centralHeatingMode = new BoolValueName("Central heating mode");
                this.tapWaterMode = new BoolValueName("Tap water mode");
                this.flameStatus = new BoolValueName("Flame status");
                this.coolingStatus = new BoolValueName("Cooling status");
                this.CH2Mode = new BoolValueName("CH2 mode");
                this.diagnosticIndication = new BoolValueName("Diagnostic indication");

                this.controlSetPoint = new FloatValueName("Control setpoint");
                this.controlSetPointModified = new FloatValueName("Control setpoint modified");
                this.masterMemberID = new IntValueName("Master member ID");
                this.slaveMemberID = new IntValueName("Slave member ID");

                this.tapWaterPresent = new BoolValueName("Tap water present");
                this.controlType = new BoolValueName("Control type");
                this.coolingConfiguration = new BoolValueName("Cooling configuration");
                this.tapWaterConfiguration = new BoolValueName("Tap water configuration");
                this.masterLowOffPumpControl = new BoolValueName("Master low-off & Pump control");
                this.CH2Present = new BoolValueName("CH2 present");
                this.serviceRequest = new BoolValueName("Service request");
                this.lockoutReset = new BoolValueName("Lock out reset");
                this.lowWaterPressure = new BoolValueName("Low water pressure");
                this.gasFlamFault = new BoolValueName("Gas/ Flame fault");
                this.airPressureFault = new BoolValueName("Air pressure fault");
                this.waterOverTemp = new BoolValueName("Water overtempearatur");
                this.OEMFaultCode = new IntValueName("OEM specific fault code");

                this.controlSetPoint2 = new FloatValueName("Control setpoint 2");
                this.roomSetPoint = new FloatValueName("Room setpoint");
                this.relativeModulationLevel = new FloatValueName("Relative modulation level");
                this.waterPressureCHCircuit = new FloatValueName("Water pressure central heating system");
                this.waterFlowRateTap = new FloatValueName("Water flow rate tap water");
                this.timeAndDay = new IntValueName("Time abd day of week");
                this.date = new IntValueName("Date");
                this.year = new IntValueName("Year");

                this.roomSetpoint2 = new FloatValueName("Room setpoint 2");
                this.roomTemperature = new FloatValueName("Room temperature");
                this.boilerWaterTemperature = new FloatValueName("Boiler water temperature");
                this.tapWaterTemperature = new FloatValueName("Tap water temperature");
                this.outsideTemperature = new FloatValueName("Outside temperature");
                this.returnWaterTemperature = new FloatValueName("Return water temperature");
                this.solarStorageTemperature = new FloatValueName("Solar storage temperature");
                this.solarCollectorTemperature = new IntValueName("Solar collector temperature");
                this.flowTemperatureCH2 = new FloatValueName("Flow temperature CH2");
                this.tapWaterTemperature2 = new FloatValueName("Tap water temperature 2");
                this.exhaustTemperature = new IntValueName("Exhaust temperature");

                this.OEMDiagnosticCode = new IntValueName("OEM Diagnostic code");

                this.burnerStarts = new IntValueName("Burner starts");
                this.pumpStarts = new IntValueName("Pump starts");
                this.tapWaterValveStarts = new IntValueName("Tap water valve starts");
                this.tapWaterBurnerStarts = new IntValueName("Tap water burner starts");
                this.burnerOperatingHours = new IntValueName("Burner operating hours");
                this.pumpOperatingHours = new IntValueName("Pump operating hours");
                this.tapWaterValveHours = new IntValueName("Tap water valve operating hours");
                this.tapWaterBurnerHours = new IntValueName("Tap water burber operating hours");
                this.openthermVersionMaster = new FloatValueName("OpenTherm version master");
                this.openthermVersionSlave = new FloatValueName("OpenTherm version slave");
                this.productTypeMaster = new IntValueName("Product type master");
                this.productVersionMaster = new IntValueName("Product version master");
                this.productTypeSlave = new IntValueName("Product type slave");
                this.productVersionSlave = new IntValueName("Product version slave");
            }
        }
        public GatewayStatus gatewayStatus;

        private SocketReader socketReader;
        private Thread socketThread;
        private volatile bool socketThreadShouldClose;
        private volatile bool socketThreadHasClosed;

        private CommandQueue commandQueue;
        private Parser parser;


  

        public OTGW()
        {
            this.gatewayConfiguration = new GatewayConfiguration();
            this.gatewayStatus = new GatewayStatus();
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


