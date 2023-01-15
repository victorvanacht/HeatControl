using System;
using System.Collections.Generic;
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
                        ["H"] = new ParserHello(),
                        ["M"] = new ParserMetadata(),
                    };
                }

                public void Parse(string line)
                {
                    char[] lineBytes = line.ToUpper().ToCharArray();

                    if (line.Length >= 2)
                    {
                        if (line[1] == ':')
                        {
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
                                case DeviceType.HeatingThermostat:
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

                            }
                        }
                    }

                    private bool AssertDevice(DeviceBase device, byte[] data)
                    {
                        bool r = true;
                        if (MaxCube.GetRfAddress(data,1) != device.rfAddress) { r = false; }
                        if ((DeviceType)data[4] != device.type) { r = false; }
                        if (data[5] != device.room.roomID) { r = false; }
                        if (!Encoding.UTF8.GetString(data, 8, 10).Equals(device.serialNumber)) { r = false; }
                        return r;
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
                        device.maxValveSettingPercent = (((float)data[index++]) * 100 / 255);
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


                private class ParserHello : ParserBase
                {
                    public override void Parse(MaxCube maxCube, string message)
                    {
                        string[] element = message.Split(',');

                        maxCube.serial = element[0];
                        maxCube.RFAddress = int.Parse(element[1], System.Globalization.NumberStyles.HexNumber);
                        maxCube.version = element[2].Substring(0, 2) + "." + element[2].Substring(2, 1) + "." + element[2].Substring(3, 1);
                        maxCube.dutyCycle = int.Parse(element[5], System.Globalization.NumberStyles.HexNumber);
                        maxCube.freeMemorySlots = int.Parse(element[6], System.Globalization.NumberStyles.HexNumber);

                        string year = (2000 + int.Parse(element[7].Substring(0, 2), System.Globalization.NumberStyles.HexNumber)).ToString();
                        string month = int.Parse(element[7].Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                        string day = int.Parse(element[7].Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                        string hour = int.Parse(element[8].Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                        string minute = int.Parse(element[8].Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
                        string dateTime = year + "-" + month + "-" + day + " " + hour + ":" + minute;
                        maxCube.dateTime = DateTime.Parse(dateTime);
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


