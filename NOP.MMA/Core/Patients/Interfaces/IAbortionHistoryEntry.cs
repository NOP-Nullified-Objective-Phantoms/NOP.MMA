using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public interface IAbortionHistoryEntry
    {
        int Year { get; set; }
        string PlannedAbortionGA { get; set; }
        string UnplannedAbortionGA { get; set; }
    }
}