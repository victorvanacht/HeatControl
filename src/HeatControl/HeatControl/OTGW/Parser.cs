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
                
                this.decodeMessages = new Dictionary<string, ParsersBase>
                {
                    [Message.GenerateKey(0, Message.Direction.ThermostatToBoiler, Message.Type.M2SReadData)] = 
                        new Flags16(
                            new List<Flags16Element>() {
                                new Flags16Element(8, ref gatewayStatus.centralHeatingEnable),
                                new Flags16Element(9, ref gatewayStatus.tapWaterEnable),
                                new Flags16Element(10, ref gatewayStatus.coolingEnable),
                                new Flags16Element(11, ref gatewayStatus.OTCActive),
                                new Flags16Element(12, ref gatewayStatus.CH2Enable)

                            }
                        ),
                    [Message.GenerateKey(0, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] =
                        new Flags16(
                            new List<Flags16Element>() {
                                new Flags16Element(0, ref gatewayStatus.faultIndication),
                                new Flags16Element(1, ref gatewayStatus.centralHeatingMode),
                                new Flags16Element(2, ref gatewayStatus.tapWaterMode),
                                new Flags16Element(3, ref gatewayStatus.flameStatus),
                                new Flags16Element(4, ref gatewayStatus.coolingStatus),
                                new Flags16Element(5, ref gatewayStatus.CH2Mode),
                                new Flags16Element(6, ref gatewayStatus.diagnosticIndication)
                            }
                        ),
                    [Message.GenerateKey(1, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] =
                        new Float88(ref gatewayStatus.controlSetPoint),
                    [Message.GenerateKey(1, Message.Direction.ThermostatToBoilerModified, Message.Type.M2SWriteData)] =
                        new Float88(ref gatewayStatus.controlSetPointModified),
                    [Message.GenerateKey(2, Message.Direction.ThermostatToBoiler, Message.Type.M2SWriteData)] =
                        new U88HL(
                            new List<IntValueName>() {
                                gatewayStatus.masterMemberID,
                                null,
                            }
                        ),
                    [Message.GenerateKey(3, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] =
                        new Flags16(
                            new List<Flags16Element>() {
                                new Flags16Element(8, ref gatewayStatus.tapWaterPresent),
                                new Flags16Element(9, ref gatewayStatus.controlType),
                                new Flags16Element(10, ref gatewayStatus.coolingConfiguration),
                                new Flags16Element(11, ref gatewayStatus.tapWaterConfiguration),
                                new Flags16Element(12, ref gatewayStatus.masterLowOffPumpControl),
                                new Flags16Element(13, ref gatewayStatus.CH2Present)
                            }
                        ),
                    [Message.GenerateKey(5, Message.Direction.BoilerToThermostat, Message.Type.S2MReadAck)] =
                        new Flags16(
                            new List<Flags16Element>() {
                                new Flags16Element(8, ref gatewayStatus.serviceRequest),
                                new Flags16Element(9, ref gatewayStatus.lockoutReset),
                                new Flags16Element(10, ref gatewayStatus.lowWaterPressure),
                                new Flags16Element(11, ref gatewayStatus.gasFlamFault),
                                new Flags16Element(12, ref gatewayStatus.airPressureFault),
                                new Flags16Element(13, ref gatewayStatus.waterOverTemp)
                            }
                        ),
                };
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

            abstract private class ParsersBase
            {
                abstract public void Parse(Message message);
            }


            class Flags16Element
            {
                public int bit;
                public BoolValueName value;

                public Flags16Element(int bit, ref BoolValueName value)
                {
                    this.bit = bit;
                    this.value = value;
                }

            }
            private class Flags16 : ParsersBase
            {
                private List<Flags16Element> arg;
                public Flags16(List<Flags16Element> arg)
                {
                    this.arg = arg;
                }

                override public void Parse(Message message)
                {
                    foreach (Flags16Element item in this.arg)
                    {
                        Flags16Element i = item;
                        i.value.value = Convert.ToBoolean(((message.dataValue) >> (item.bit)) & 1);
                    }
                }
            }

            private class Float88 : ParsersBase
            {
                private FloatValueName arg;

                public Float88(ref FloatValueName arg)
                {
                    this.arg = arg;
                }

                override public void Parse(Message message)
                {
                    arg.value = ((float)(message.dataValue)) / 256;
                }
            }


            private class U88HL : ParsersBase
            {
                private List<IntValueName> arg;

                // element 0 of list is LOW 8 bits
                // element 1 of list is HIGH 8 bits
                // if element not used, it can be null
                public U88HL(List<IntValueName> arg)
                {
                    Debug.Assert(arg.Count == 2);
                    this.arg = arg;
                }

                override public void Parse(Message message)
                {
                    if (arg[0] != null)
                    {
                        arg[0].value = message.dataValue & 0xff;
                    }
                    if (arg[1] != null)
                    {
                        arg[1].value = (message.dataValue >> 8) & 0xff;
                    }
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
                    { //@@@@@ this needs to be modified
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
                            if (decodeMessages.ContainsKey(key))
                            {
                                ParsersBase handler = decodeMessages[key];
                                handler.Parse(message);

                            }
                        }
                    }
                }

                return message;
            }
        }
    }
}


