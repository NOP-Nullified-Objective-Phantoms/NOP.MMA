using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// A history record of an abortion
    /// </summary>
    public class AbortionHistoryEntry : IAbortionHistoryEntry
    {
        public int Year { get; set; }
        public string PlannedAbortionGA { get; set; }
        public string UnplannedAbortionGA { get; set; }
    }
}
