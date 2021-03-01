using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct WorkEnvironmentEffect
    {
        public string WorkPosition { get; set; }
        public int WorkHoursPrWeek { get; set; }
        public string FathersWorkPosition { get; set; }

        public WorkEnvironment[] WorkEnvironmentS { get; set; }
        public string NatureAndPeriod { get; set; }
        public bool ReferedToOMClinic { get; set; }
        public bool PartialLeaveNotification { get; set; }
        public bool LeaveNotification { get; set; }
    }
}