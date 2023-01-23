using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeatControl
{
    partial class MaxCubeLogger
    {
        partial class MaxCube
        {
            private class Parser
            {
                MaxCube maxCube;

                Dictionary<string, ParserBase> decodeMessage;



                public Parser(MaxCube maxCube)
                {
                    this.maxCube = maxCube;

                    this.decodeMessage = new Dictionary<string, ParserBase>()
                    {
                        ["C"] = new ParserConfiguration(),
                        ["F"] = new ParserNTPServer(),
                        ["H"] = new ParserHello(),
                        ["M"] = new ParserMetadata(),
                        ["L"] = new ParserList()
                    };
                }

                public void Parse(string line)
                {
                    char[] lineBytes = line.ToUpper().ToCharArray();

                    if (line.Length >= 2)
                    {
                        if (line[1] == ':')
                        {
                            this.maxCube.commandQueue.TryDequeueCommand(line.Substring(0, 2));

                            string messageType = line.Substring(0, 1);
                            if (this.decodeMessage.ContainsKey(messageType))
                            {
                                this.decodeMessage[messageType].Parse(this.maxCube, line.Substring(2));
                            }
                        }
                    }
                }

                private abstract class ParserBase
                {
                    abstract public void Parse(MaxCube maxCube, string message);
                }

                private class ParserConfiguration : ParserBase
                {
                    public override void Parse(MaxCube maxCube, string message)
                    {
                        string[] element = message.Split(',');
                        int rfAddress = int.Parse(element[0], System.Globalization.NumberStyles.HexNumber);
                        byte[] data = System.Convert.FromBase64String(element[1]);

                        if (maxCube.deviceLookup.ContainsKey(rfAddress))
                        {
                            DeviceBase device = maxCube.deviceLookup[rfAddress];
                            
                            switch (device.type)
                            {
                                case DeviceType.Cube:
                                    if (!this.AssertDevice(device, data, false)) // do not check roomID.
                                    {
                                        throw new Exception("Internal data error");
                                    }
                                    this.ParseCube((DeviceMaxCube)device, data);
                                    break;
                                case DeviceType.HeatingThermostat:
                                case DeviceType.HeatingThermostatTODO: // do we need to fix this??
                                    if (!this.AssertDevice(device, data))
                                    {
                                        throw new Exception("Internal data error");
                                    }
                                    this.ParseHeatingThermostat((DeviceHeatingThermostat)device, data);
                                    break;
                                case DeviceType.WallThermostat:
                                    if (!this.AssertDevice(device, data))
                                    {
                                        throw new Exception("Internal data error");
                                    }
                                    this.ParseWallThermostat((DeviceWallThermostat)device, data);
                                    break;
                                case DeviceType.EcoSwitch:
                                    // no information available on how to parse this message.
                                    break;
                                default:
                                    throw new Exception("not implemented");

                            }
                        }
                        else
                        {
                            throw new Exception("rfAddress not found");
                        }
                    }

                    private bool AssertDevice(DeviceBase device, byte[] data)
                    {
                        return AssertDevice(device, data, true);
                    }

                    private bool AssertDevice(DeviceBase device, byte[] data, bool checkRoomID)
                    {
                        bool r = true;
                        if (MaxCube.GetRfAddress(data,1) != device.rfAddress) { r = false; }
                        if ((DeviceType)data[4] != device.type) { r = false; }
                        if (checkRoomID && (data[5] != device.room.roomID)) { r = false; }
                        if (!Encoding.UTF8.GetString(data, 8, 10).Equals(device.serialNumber)) { r = false; }
                        return r;
                    }

                    private void ParseCube(DeviceMaxCube device, byte[] data)
                    {
                        device.portalEnabled = (data[0x12] != 0);
                        device.pushButtonUpConfig = data[0x1e];
                        device.pushButtonDownConfig = data[0x3f];
                        device.portalURL = Encoding.UTF8.GetString(data, 0x55, 127);
                    }

                    private void ParseWallThermostat(DeviceWallThermostat device, byte[] data)
                    {
                        int index = 0x12;
                        device.comfortTemperature = ((float)data[index++])/2;
                        device.ecoTemperature = ((float)data[index++]) / 2;
                        device.maxSetpointTemperature = ((float)data[index++]) / 2;
                        device.minSetpointTemperature = ((float)data[index++]) / 2;

                        for (int day = 0; day < 7; day++)
                        {
                            for (int i = 0; i < 13; i++)
                            {
                                float temperature = ((float)(data[index] >> 1)) / 2;
                                int until = (((data[index] & 1) << 8) + data[index + 1]) * 5;
                                int hours = until / 60;
                                int minutes = until % 60;
                                device.program[day][i] = new DeviceBase.ProgramEntry(temperature, hours, minutes);
                                index += 2;
                            }
                        }
                    }

                    private void ParseHeatingThermostat(DeviceHeatingThermostat device, byte[] data)
                    {
                        int index = 0x12;
                        device.comfortTemperature = ((float)data[index++]) / 2;
                        device.ecoTemperature = ((float)data[index++]) / 2;
                        device.maxSetpointTemperature = ((float)data[index++]) / 2;
                        device.minSetpointTemperature = ((float)data[index++]) / 2;
                        device.temperatureOffset = (((float)data[index++]) -3.5f) / 2;
                        device.windowOpenTemperature = ((float)data[index++]) / 2;
                        device.windowOpenDuration = data[index++] * 5; // TODO: check if this should not be / 5
                        device.boostDuration = (data[index] >>5) * 5;
                        device.boostValvePercentage = (data[index++] & 0x1F) * 5;
                        device.decalcificationDay = data[index] >> 5;
                        device.decalcificationHours = data[index++] & 0x1F;
                        device.valveMaxPercent = (((float)data[index++]) * 100 / 255);
                        device.valveOffsetPercent = (((float)data[index++]) * 100 / 255);

                        for (int day = 0; day < 7; day++)
                        {
                            for (int i = 0; i < 13; i++)
                            {
                                float temperature = ((float)(data[index] >> 1)) / 2;
                                int until = (((data[index] & 1) << 8) + data[index + 1]) * 5;
                                int hours = until / 60;
                                int minutes = until % 60;
                                device.program[day][i] = new DeviceBase.ProgramEntry(temperature, hours, minutes);
                                index += 2;
                            }
                        }
                    }

                }

                private class ParserNTPServer : ParserBase
                {
                    public override void Parse(MaxCube maxCube, string message)
                    {
                        maxCube.deviceMaxCube.NTPserver = message;
                    }
                }


                private class ParserHello : ParserBase
                {
                    public override void Parse(MaxCube maxCube, string message)
                    {
                        string[] element = message.Split(',');

                        maxCube.deviceMaxCube.serialNumber = element[0];
                        maxCube.deviceMaxCube.rfAddress = int.Parse(element[1], System.Globalization.NumberStyles.HexNumber);
                        maxCube.deviceMaxCube.version = element[2].Substring(0, 2) + "." + element[2].Substring(2, 1) + "." + element[2].Substring(3, 1);
                        maxCube.deviceMaxCube.dutyCycle = int.Parse(element[5], System.Globalization.NumberStyles.HexNumber);
                        maxCube.deviceMaxCube.freeMemorySlots = int.Parse(element[6], System.Globalization.NumberStyles.HexNumber);

                        string year = (2000 + int.Parse(element[7].Substring(0, 2), System.Globalization.NumberStyles.HexNumber)).ToString();
                        string month = int.Parse(element[7].Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                        string day = int.Parse(element[7].Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                        string hour = int.Parse(element[8].Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                        string minute = int.Parse(element[8].Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                        string dateTime = year + "-" + month + "-" + day + " " + hour + ":" + minute;
                        maxCube.deviceMaxCube.dateTime = DateTime.Parse(dateTime);

                        maxCube.deviceLookup.Add(maxCube.deviceMaxCube.rfAddress, maxCube.deviceMaxCube);
                    }
                }

                private class ParserList : ParserBase
                {
                    public override void Parse(MaxCube maxCube, string message)
                    {
                        byte[] data = System.Convert.FromBase64String(message);
                        int index = 0;

                        while ((index < (data.Length-3)) && (data[index] != 0xce) && (data[index+1] != 0x00))
                        {
                            int indexStartOfMessage = index; // store this value for later
                            int messageLength = data[index++];
                            int rfAddress = MaxCube.GetRfAddress(data, index);
                            index += 4; // 3 for rfAddress and 1 for unknown
                            int flags = (data[index]<<8) + data[index+1];
                            index += 2;
                            int valvePosition=-1;
                            float configuredTemperature=-1;
                            int storeForLater=-1;
                            int dateUntil=-1;
                            int timeUntil=-1;
                            float actualTemperature=-1;
                            if (messageLength > 6)
                            {
                                valvePosition = data[index++];
                                configuredTemperature = ((float)(data[index] & 0x7f))/2;
                                storeForLater = (data[index++]&0x80) <<1;
                                dateUntil = (data[index] << 8) + data[index + 1];
                                index += 2;
                                timeUntil = data[index++];
                            }
                            if (messageLength == 12)
                            {
                                actualTemperature = ((float)(data[index++] + storeForLater)) / 10;
                            }


                            if (maxCube.deviceLookup.ContainsKey(rfAddress))
                            {
                                DeviceBase device = maxCube.deviceLookup[rfAddress];

                                switch (device.type)
                                {
                                    case DeviceType.Cube:
                                        throw new Exception("to do");
                                        break;
                                    case DeviceType.HeatingThermostat:
                                    case DeviceType.HeatingThermostatTODO: // do we need to fix this??
                                        DeviceHeatingThermostat heatingThermostat = (DeviceHeatingThermostat) device;
                                        heatingThermostat.valvePosition = valvePosition;
                                        heatingThermostat.configuredTemperature= configuredTemperature;
                                        break;
                                    case DeviceType.WallThermostat:
                                        DeviceWallThermostat wallThermostat = (DeviceWallThermostat)device;
                                        wallThermostat.configuredTemperature = configuredTemperature;
                                        wallThermostat.actualTemperature = actualTemperature;
                                        wallThermostat.room.configuredTemperature = configuredTemperature;
                                        wallThermostat.room.actualTemperature = actualTemperature;
                                        break;
                                    case DeviceType.EcoSwitch:
                                        // TODO: throw new Exception("to do");
                                        break;
                                    default:
                                        throw new Exception("not implemented");
                                }
                            }
                            else
                            {
                                throw new Exception("rfAddress not found");
                            }
                        }
                    }
                }

                private class ParserMetadata : ParserBase
                {
                    public override void Parse(MaxCube maxCube, string message)
                    {
                        string[] element = message.Split(',');
                        int messageIndex = int.Parse(element[0], System.Globalization.NumberStyles.HexNumber);
                        int messageCount = int.Parse(element[1], System.Globalization.NumberStyles.HexNumber);
                        byte[] data = System.Convert.FromBase64String(element[2]);

                        int index = 2;
                        int roomCount = data[index++];
                        for (int i = 0; i < roomCount; i++)
                        {
                            int roomID = data[index++];
                            int nameLenght = data[index++];
                            string name = Encoding.UTF8.GetString(data, index, nameLenght);
                            index += nameLenght;
                            int rfAddress = MaxCube.GetRfAddress(data,index);
                            index += 3;

                            maxCube.rooms.Add(roomID, new Room(name, rfAddress, roomID));
                        }

                        int deviceCount = data[index++];
                        for (int i = 0; i < deviceCount; i++)
                        {
                            DeviceType deviceType = (DeviceType)data[index++];
                            int rfAddress = MaxCube.GetRfAddress(data,index);
                            index += 3;
                            string serialNumber = Encoding.UTF8.GetString(data, index, 10);
                            index += 10;
                            int nameLenght = data[index++];
                            string name = Encoding.UTF8.GetString(data, index, nameLenght);
                            index += nameLenght;
                            int roomID = data[index++];

                            DeviceBase device = DeviceBase.CreateFromTypeID(deviceType, name, serialNumber, rfAddress, maxCube.rooms[roomID]);

                            maxCube.rooms[roomID].devices.Add(device);
                            if (!maxCube.deviceLookup.ContainsKey(rfAddress)) maxCube.deviceLookup.Add(rfAddress, device);
                        }
                    }
                }
            }
        }
    }
}


