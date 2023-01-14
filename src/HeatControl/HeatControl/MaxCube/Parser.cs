using System;
using System.Collections.Generic;
using System.Linq;
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
                        ["H"] = new ParserHello(),
                    };
                }

                public void Parse(string line)
                {
                    char[] lineBytes = line.ToUpper().ToCharArray();

                    if (line.Length >=2)
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

            }
        }
    }
}
