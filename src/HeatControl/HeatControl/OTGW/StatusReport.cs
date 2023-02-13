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
                this.centralHeatingEnable = new BoolValueName("Central heating enable");
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

        public class StatusReport
        {
            public DateTime dateTime;
            public BoolValueName centralHeatingMode;
            public BoolValueName tapWaterMode;
            public BoolValueName flameStatus;

            public FloatValueName controlSetPoint;
            public FloatValueName controlSetPointModified;
            public FloatValueName relativeModulationLevel;
            public FloatValueName roomSetPoint;
            public FloatValueName boilerWaterTemperature;
            public FloatValueName tapWaterTemperature;
            public FloatValueName outsideTemperature;
            public FloatValueName returnWaterTemperature;

            public StatusReport(GatewayStatus status)
            {
                this.dateTime = DateTime.Now;

                this.flameStatus = status.flameStatus;
                this.centralHeatingMode = status.centralHeatingMode;
                this.tapWaterMode = status.tapWaterMode;

                this.controlSetPoint = status.controlSetPoint;
                this.controlSetPointModified = status.controlSetPointModified;
                this.relativeModulationLevel = status.relativeModulationLevel;
                this.roomSetPoint = status.roomSetPoint;
                this.boilerWaterTemperature = status.boilerWaterTemperature;
                this.tapWaterTemperature = status.tapWaterTemperature;
                this.outsideTemperature = status.outsideTemperature;
                this.returnWaterTemperature = status.returnWaterTemperature;
            }

            public static string heading
            {
                get
                {
                    GatewayStatus dummyStatus = new GatewayStatus();
                    return "Date Time; " +
                        dummyStatus.flameStatus.name + "; " +
                        dummyStatus.centralHeatingMode.name + "; " +
                        dummyStatus.tapWaterMode.name + "; " +
                        dummyStatus.controlSetPoint.name + "; " +
                        dummyStatus.controlSetPointModified.name + "; " +
                        dummyStatus.relativeModulationLevel.name + "; " +
                        dummyStatus.roomSetPoint.name + "; " +
                        dummyStatus.boilerWaterTemperature.name + "; " +
                        dummyStatus.tapWaterTemperature.name + "; " +
                        dummyStatus.outsideTemperature.name + "; " +
                        dummyStatus.returnWaterTemperature.name;
                }
            }

            override public string ToString()
            {
                return this.dateTime.ToString() + "; " +
                    this.flameStatus.value.ToString() + "; " +
                    this.centralHeatingMode.value.ToString() + "; " +
                    this.tapWaterMode.value.ToString() + "; " +
                    this.controlSetPoint.value.ToString() + "; " +
                    this.controlSetPointModified.value.ToString() + "; " +
                    this.relativeModulationLevel.value.ToString() + "; " +
                    this.roomSetPoint.value.ToString() + "; " +
                    this.boilerWaterTemperature.value.ToString() + "; " +
                    this.tapWaterTemperature.value.ToString() + "; " +
                    this.outsideTemperature.value.ToString() + "; " +
                    this.returnWaterTemperature.value.ToString();
            }
        }
    }
}