using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public interface IPregnancyHistoryEntry
    {
        int Year { get; set; }
        bool BornAlive { get; set; }
        bool StillBorn { get; set; }
        bool Male { get; set; }
        string GestationAge { get; set; }
        double Weight { get; set; }
        string PlaceOfBirth { get; set; }
        string PregnancyProgress { get; set; }
        Experience PregnancyExperience { get; set; }
        string CurrentStatusOfChild { get; set; }
    }
}