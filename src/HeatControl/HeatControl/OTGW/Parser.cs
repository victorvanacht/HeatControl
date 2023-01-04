using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HeatControl
{
    partial class OTGW
    {
        private class Parser
        {
            private GatewayConfiguration gatewayConfiguration;
            private GatewayStatus gatewayStatus;
            private CommandQueue commandQueue;
            private Dictionary<string, List<ParsersBase>> decodeMessages;

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
                public string line;

                public Message(string line)
                {
                    this.line = line;
                }

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
                
                this.decodeMessages = new Dictionary<string, List<ParsersBase>>
                {
                    [Message.GenerateKey(0, Message.Direction.ThermostatToBoiler, Message.Type.M2SReadData)] = new List<ParsersBase>() {
                        new Flags16Parser(8, ref gatewayStatus.centralHeatingEnable),
                        new Flags16Parser(9, ref gatewayStatus.tapWaterEnable),
                        new Flags16Parser(10, ref gatewayStatus.coolingEnable),
                        new Flags16Parser(11, ref gatewayStatus.OTCActive),
                        new Flags16Parser(12, ref gatewayStatus.CH2Enable)},
                    [Message.GenerateKey(0, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() { 
                        new Flags16Parser(0, ref gatewayStatus.faultIndication),
                        new Flags16Parser(1, ref gatewayStatus.centralHeatingMode),
                        new Flags16Parser(2, ref gatewayStatus.tapWaterMode),
                        new Flags16Parser(3, ref gatewayStatus.flameStatus),
                        new Flags16Parser(4, ref gatewayStatus.coolingStatus),
                        new Flags16Parser(5, ref gatewayStatus.CH2Mode),
                        new Flags16Parser(6, ref gatewayStatus.diagnosticIndication)},
                    [Message.GenerateKey(1, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.controlSetPoint)},
                    [Message.GenerateKey(1, Message.Direction.ThermostatToBoilerModified, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.controlSetPointModified)},
                    [Message.GenerateKey(2, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Uint8Parser(8, ref gatewayStatus.masterMemberID)},
                    [Message.GenerateKey(3, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint8Parser(0, ref gatewayStatus.slaveMemberID),
                        new Flags16Parser(8, ref gatewayStatus.tapWaterPresent),
                        new Flags16Parser(9, ref gatewayStatus.controlType),
                        new Flags16Parser(10, ref gatewayStatus.coolingConfiguration),
                        new Flags16Parser(11, ref gatewayStatus.tapWaterConfiguration),
                        new Flags16Parser(12, ref gatewayStatus.masterLowOffPumpControl),
                        new Flags16Parser(13, ref gatewayStatus.CH2Present)},
                    [Message.GenerateKey(5, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint8Parser(0, ref gatewayStatus.OEMFaultCode),
                        new Flags16Parser(8, ref gatewayStatus.serviceRequest),
                        new Flags16Parser(9, ref gatewayStatus.lockoutReset),
                        new Flags16Parser(10, ref gatewayStatus.lowWaterPressure),
                        new Flags16Parser(11, ref gatewayStatus.gasFlamFault),
                        new Flags16Parser(12, ref gatewayStatus.airPressureFault),
                        new Flags16Parser(13, ref gatewayStatus.waterOverTemp)},
                    [Message.GenerateKey(8, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.controlSetPoint2)},
                    [Message.GenerateKey(16, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.roomSetPoint)},
                    [Message.GenerateKey(17, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.relativeModulationLevel)},
                    [Message.GenerateKey(18, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.waterPressureCHCircuit)},
                    [Message.GenerateKey(19, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.waterFlowRateTap)},
                    [Message.GenerateKey(20, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.timeAndDay)},
                    [Message.GenerateKey(20, Message.Direction.BoilerToThermostat, Message.Type.S2MWriteAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.timeAndDay)},
                    [Message.GenerateKey(21, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.date)},
                    [Message.GenerateKey(21, Message.Direction.BoilerToThermostat, Message.Type.S2MWriteAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.date)},
                    [Message.GenerateKey(22, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.year)},
                    [Message.GenerateKey(22, Message.Direction.BoilerToThermostat, Message.Type.S2MWriteAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.year)},
                    [Message.GenerateKey(23, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.roomSetpoint2)},
                    [Message.GenerateKey(24, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.roomTemperature)},
                    [Message.GenerateKey(25, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.boilerWaterTemperature)},
                    [Message.GenerateKey(26, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.tapWaterTemperature)},
                    [Message.GenerateKey(27, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.outsideTemperature)},
                    [Message.GenerateKey(28, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.returnWaterTemperature)},
                    [Message.GenerateKey(29, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.solarStorageTemperature)},
                    [Message.GenerateKey(30, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Sint16Parser(ref gatewayStatus.solarCollectorTemperature)},
                    [Message.GenerateKey(31, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.flowTemperatureCH2)},
                    [Message.GenerateKey(32, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.tapWaterTemperature2)},
                    [Message.GenerateKey(33, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Sint16Parser(ref gatewayStatus.exhaustTemperature)},
                    [Message.GenerateKey(115, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.OEMDiagnosticCode)},
                    [Message.GenerateKey(116, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.burnerStarts)},
                    [Message.GenerateKey(117, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.pumpStarts)},
                    [Message.GenerateKey(118, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.tapWaterValveStarts)},
                    [Message.GenerateKey(119, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.tapWaterBurnerStarts)},
                    [Message.GenerateKey(120, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.burnerOperatingHours)},
                    [Message.GenerateKey(121, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.pumpOperatingHours)},
                    [Message.GenerateKey(122, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.tapWaterValveHours)},
                    [Message.GenerateKey(123, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint16Parser(ref gatewayStatus.tapWaterBurnerHours)},
                    [Message.GenerateKey(124, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.openthermVersionMaster)},
                    [Message.GenerateKey(125, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Float88Parser(ref gatewayStatus.openthermVersionSlave)},
                    [Message.GenerateKey(126, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] = new List<ParsersBase>() {
                        new Uint8Parser(0, ref gatewayStatus.productVersionMaster),
                        new Uint8Parser(8, ref gatewayStatus.productTypeMaster)},
                    [Message.GenerateKey(127, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] = new List<ParsersBase>() {
                        new Uint8Parser(0, ref gatewayStatus.productVersionSlave),
                        new Uint8Parser(8, ref gatewayStatus.productTypeSlave)},

                    ["NG"] = new List<ParsersBase>() { new ErrorParser("No Good") },
                    ["SE"] = new List<ParsersBase>() { new ErrorParser("Syntax error") },
                    ["BV"] = new List<ParsersBase>() { new ErrorParser("Bad value") },
                    ["OR"] = new List<ParsersBase>() { new ErrorParser("Out of range") },
                    ["NS"] = new List<ParsersBase>() { new ErrorParser("No space") },
                    ["NF"] = new List<ParsersBase>() { new ErrorParser("Not found") },
                    ["OR"] = new List<ParsersBase>() { new ErrorParser("Overrun") },

                    ["PR: A"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.version) },
                    ["PR: B"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.build) },
                    ["PR: C"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.clockSpeed) },
                    ["PR: D"] = new List<ParsersBase>() { new StringReplaceParser(6, 1, ref this.gatewayConfiguration.temperaturSensorFunction, new Dictionary<string,string> {
                        ["O"] = "Outside temperature",
                        ["R"] = "Return water temperature" }) },                        
                    ["PR: G"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.gpioFunctionsConfiguration) },
                    ["PR: I"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.gpioState) },
                    ["PR: L"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.ledFunctionsConfiguration) },
                    ["PR: M"] = new List<ParsersBase>() { new StringReplaceParser(6, 1, ref this.gatewayConfiguration.gatewayMode, new Dictionary<string,string> {
                        ["G"] = "Gateway",
                        ["M"] = "Monitor" }) },
                    ["PR: O"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.setpointOverride) },
                    ["PR: P"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.smartPowerModel) },
                    ["PR: Q"] = new List<ParsersBase>() { new StringReplaceParser(6, 1, ref this.gatewayConfiguration.causeOfLastReset, new Dictionary<string,string> {
                        ["B"] = "Brown out",
                        ["C"] = "By Command",
                        ["E"] = "Reset button",
                        ["L"] = "Stuck in loop",
                        ["O"] = "Stack overflow",
                        ["P"] = "Power on",
                        ["S"] = "BREAK on serial interface",
                        ["U"] = "Stack undeflow",
                        ["W"] = "Watchdog" }) },
                    ["PR: R"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.remehaDetectionState) },
                    ["PR: S"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.setbackTemperatureConfiguarion) },
                    ["PR: T"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.tweaks) },
                    ["PR: V"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.referenceVoltage) },
                    ["PR: W"] = new List<ParsersBase>() { new StringParser(6, ref this.gatewayConfiguration.hotWater) },
                };
            }

            abstract private class ParsersBase
            {
                abstract public void Parse(Message message);
            }


            private class Flags16Parser : ParsersBase
            {
                private int bit;
                private BoolValueName value;

                public Flags16Parser(int bit, ref BoolValueName value)
                {
                    this.bit = bit;
                    this.value = value;
                }

                override public void Parse(Message message)
                {
                    value.value = Convert.ToBoolean(((message.dataValue) >> (this.bit)) & 1);
                }
            }

            private class Float88Parser : ParsersBase
            {
                private FloatValueName arg;

                public Float88Parser(ref FloatValueName arg)
                {
                    this.arg = arg;
                }

                override public void Parse(Message message)
                {
                    arg.value = (float)Math.Round(((float)(message.dataValue)) / 256, 1);
                }
            }


            private class Uint8Parser : ParsersBase
            {
                private int bit;
                private IntValueName value;

                public Uint8Parser(int bit, ref IntValueName value)
                {
                    this.bit = bit;
                    this.value = value;
                }

                override public void Parse(Message message)
                {
                    value.value = (message.dataValue>> bit) & 0xff;
                }
            }

            private class Uint16Parser : ParsersBase
            {
                private IntValueName value;

                public Uint16Parser(ref IntValueName value)
                {
                    this.value = value;
                }

                override public void Parse(Message message)
                {
                    value.value = message.dataValue;
                }
            }

            private class Sint16Parser : ParsersBase
            {
                private IntValueName value;

                public Sint16Parser(ref IntValueName value)
                {
                    this.value = value;
                }

                override public void Parse(Message message)
                {
                    value.value = message.dataValue;
                    if (value.value > 32767) value.value -= 65536;
                }
            }

            private class StringParser : ParsersBase
            {
                private int firstChar;
                private StringValueName value;

                public StringParser(int firstChar, ref StringValueName value)
                {
                    this.firstChar = firstChar;
                    this.value = value;
                }

                override public void Parse(Message message)
                {
                    value.value = message.line.Substring(firstChar);
                }
            }

            private class StringReplaceParser : ParsersBase
            {
                private int firstChar;
                private int stringLength;
                private StringValueName value;
                private Dictionary<string, string> replaceStrings;

                public StringReplaceParser(int firstChar, int stringLength, ref StringValueName value, Dictionary<string, string> replaceStrings)
                {
                    this.firstChar = firstChar;
                    this.stringLength = stringLength;
                    this.value = value;
                    this.replaceStrings = replaceStrings;
                }

                override public void Parse(Message message)
                {
                    string key = message.line.Substring(this.firstChar, this.stringLength);
                    if (this.replaceStrings.ContainsKey(key)) {
                        value.value = this.replaceStrings[key];
                    }
                }
            }


            private class ErrorParser : ParsersBase
            {
                private string errorMessage;

                public ErrorParser(string errorMessage)
                {
                    this.errorMessage = errorMessage;
                }

                override public void Parse(Message message)
                {
                    Console.WriteLine("Error: " + errorMessage);
                }
            }


        public Message Parse(string line)
            {
                Message message = null;

                char[] lineBytes = line.ToUpper().ToCharArray();

                // parse error messages
                if (line.Length == 2)
                {
                    if (decodeMessages.ContainsKey(line))
                    {
                        decodeMessages[line][0].Parse(message);
                    }
                }
                else if (line.Length >= 5)
                {
                    // parse "PR:" request response
                    string res = line.Substring(0, 5);

                    if (decodeMessages.ContainsKey(res))
                    {
                        commandQueue.TryDequeueCommand(res.Substring(0,2));
                        decodeMessages[res][0].Parse(new Message(line));
                    }

                    else if (line.Length == 9)
                    {
                        message = new Message(line);
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
                            if (decodeMessages.ContainsKey(key))
                            {
                                foreach (ParsersBase handler in decodeMessages[key])
                                {
                                    handler.Parse(message);
                                }

                            }
                        }
                    }
                }
                return message;
            }
        }
    }
}



