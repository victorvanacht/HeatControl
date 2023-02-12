using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HeatControl.OTGW;
using System.IO;

namespace HeatControl
{
    partial class MaxCubeLogger
    {
        public class StatusReport
        {
            public class Radiator
            {
                public string name;
                public float valve;

                public Radiator(string name, float valve)
                {
                    this.name = name;
                    this.valve = valve;
                }
            }

            public class RoomReport
            {
                public string name;
                public float configuredTemperature;
                public float actualTemperature;
                public List<Radiator> radiators;
                public bool boostActive;

                public RoomReport(string name, float configuredTemperature, float actualTemperature, bool boostActive)
                {
                    this.radiators = new List<Radiator>();
                    this.name = name;
                    this.configuredTemperature = configuredTemperature;
                    this.actualTemperature = actualTemperature;
                    this.boostActive = boostActive;
                }
            }

            public DateTime dateTime;
            public List<RoomReport> report;

            public StatusReport(MaxCubeLogger maxCubeLogger)
            {
                this.dateTime = DateTime.Now;
                this.report = new List<RoomReport>();

                foreach (MaxCube maxCube in maxCubeLogger.maxCubes)
                {
                    foreach (KeyValuePair<int, MaxCube.Room> kvp in maxCube.rooms)
                    {
                        MaxCube.Room room = kvp.Value;
                        if (room.roomID != 0)
                        {
                            RoomReport roomReport = new RoomReport(room.name, room.configuredTemperature, room.actualTemperature, room.boostActive);
                            if ((DateTime.Now - room.lastUpdate).TotalSeconds > 300) // @@@@ still to be modified!!!!!
                            {
                                roomReport.actualTemperature = -1;
                                roomReport.configuredTemperature = -1;
                                roomReport.boostActive = false;
                            }

                            foreach (MaxCube.DeviceBase device in room.devices)
                            {
                                if ((device.type == MaxCube.DeviceType.HeatingThermostat) || (device.type == MaxCube.DeviceType.HeatingThermostatTODO))
                                {
                                    MaxCube.DeviceHeatingThermostat heatingThermostat = (MaxCube.DeviceHeatingThermostat)device;
                                    Radiator radiator = new Radiator(heatingThermostat.name, heatingThermostat.valvePosition);
                                    if ((DateTime.Now - heatingThermostat.lastUpdate).TotalSeconds > 300) // @@@ Still to be changed 
                                    {
                                        radiator.valve = -1;
                                    }
                                    roomReport.radiators.Add(radiator);
                                }
                            }
                            this.report.Add(roomReport);
                        }
                    }

                    // request new real-time status report from the devices.
                    maxCube.EnqueueCommand("l:");
                }
            }

            public string Heading()
            {
                string s = "Date Time; ";

                foreach (RoomReport roomReport in this.report)
                {
                    s += roomReport.name + " configured temperature; ";
                    s += roomReport.name + " actual temperature; ";
                    foreach (Radiator radiator in roomReport.radiators)
                    {
                        s += roomReport.name + radiator.name + " percentage; ";
                    }
                }
                return s;
            }

            override public string ToString()
            {
                string s = this.dateTime.ToString() + "; ";

                foreach (RoomReport roomReport in this.report)
                {
                    s += roomReport.configuredTemperature.ToString() + "; ";
                    s += roomReport.actualTemperature.ToString() + "; ";
                    foreach (Radiator radiator in roomReport.radiators)
                    {
                        s += radiator.valve.ToString() + "; ";
                    }
                }
                return s;
            }
        }

        public delegate void StatusReportHandler(StatusReport status);
        private List<StatusReportHandler> statusReportHandlers;


        public void AddStatusReporter(StatusReportHandler handler)
        {
            this.statusReportHandlers.Add(handler);
        }

        public void RemoveStatusReporter(StatusReportHandler handler)
        {
            this.statusReportHandlers.Remove(handler);
        }
    }
}
