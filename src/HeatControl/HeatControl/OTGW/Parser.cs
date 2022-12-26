using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
