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
        public class VarValueName<T>
        {
            public string name;
            private T _value;
            public delegate void Listener(T value);
            private List<Listener> listeners;

            public T value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;

                    foreach (Listener listener in listeners)
                    {
                        listener(_value);
                    }
                }
            }

            protected VarValueName(string name)
            {
                this.name = name;
                this.listeners = new List<Listener>();
            }

            public void AddListener(Listener listener)
            {
                this.listeners.Add(listener);
            }

            public void RemoveListener(Listener listener)
            {
                this.listeners.Remove(listener);
            }
        }



        public class IntValueName : VarValueName<int>
        {
            public IntValueName(string name) : base(name)
            {
                this.value = -1; // uninitialzed indicator
            }
        }

        public class BoolValueName : VarValueName<bool>
        {
            public BoolValueName(string name) : base(name)
            {
                this.value = false; // uninitialzed indicator????
            }


        }
        public class FloatValueName : VarValueName<float>
        {
            public FloatValueName(string name) : base(name)
            {
                this.value = -1; // uninitialzed indicator
            }

        }
        public class StringValueName : VarValueName<string>
        {
            public StringValueName(string name) : base(name)
            {
                this.value = ""; // uninitialzed indicator
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
                this.ledFunctionsConfiguration = new StringValueName("LED function configuration");
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
            public BoolValueName gasFlameFault;
            public BoolValueName airPressureFault;
            public BoolValueName waterOvertemp;
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
                this.gasFlameFault = new BoolValueName("Gas/ Flame fault");
                this.airPressureFault = new BoolValueName("Air pressure fault");
                this.waterOvertemp = new BoolValueName("Water overtempearatur");
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
            this.socketReader = new SocketReader(this);
            this.commandQueue = new CommandQueue();
            this.parser = new Parser(ref this.gatewayConfiguration, ref this.gatewayStatus, ref this.commandQueue);
            this.logHandlers = new List<LogHandler>();
        }

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
            }
            socketThreadHasClosed = true;
        }
    }
}


