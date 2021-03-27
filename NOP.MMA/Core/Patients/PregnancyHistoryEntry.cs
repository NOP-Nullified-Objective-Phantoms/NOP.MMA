using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// A history record of a pregnancy
    /// </summary>
    public class PregnancyHistoryEntry : IPregnancyHistoryEntry
    {
        public int Year { get; set; }
        public bool BornAlive { get; set; }
        public bool StillBorn { get; set; }
        public bool Male { get; set; }
        public string GestationAge { get; set; }
        public double Weight { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PregnancyProgress { get; set; }
        public Experience PregnancyExperience { get; set; }
        public string CurrentStatusOfChild { get; set; }
    }
}
