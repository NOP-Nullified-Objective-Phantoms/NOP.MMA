using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// The information about the effects of a work environment
    /// </summary>
    public class WorkEnvironmentEffect
    {
        public WorkEnvironmentEffect ()
        {
            WorkEnvironments = new WorkEnvironment[] { WorkEnvironment.NotSet, WorkEnvironment.NotSet, WorkEnvironment.NotSet, WorkEnvironment.NotSet };
        }

        public string WorkPosition { get; set; }
        public int WorkHoursPrWeek { get; set; }
        public string FathersWorkPosition { get; set; }

        /// <summary>
        /// The collection of environments the <see cref="Patients.IPatient"/> works in
        /// </summary>
        public WorkEnvironment[] WorkEnvironments { get; }
        public string NatureAndPeriod { get; set; }
        public bool ReferedToOMClinic { get; set; }
        public bool PartialLeaveNotification { get; set; }
        public bool LeaveNotification { get; set; }
    }
}