using System;
using System.Collections.Generic;
using System.Text;
using NOP.MMA.Core.Patients;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents a stamp of general information for an <see cref="IPatient"/>
    /// </summary>
    public struct JournalStamp
    {
        public DateTime Date { get; set; }
        public string GestationAge { get; set; }
        public double Weight { get; set; }
        public string BloodPressure { get; set; }
        public string UrinSample { get; set; }
        public bool Edema { get; set; }
        public double UterusSizeInCM { get; set; }
        public string FosterRepresentation { get; set; }
        public string FetusGender { get; set; }
        public bool FetusActivity { get; set; }
        public string ExaminationLocation { get; set; }
        public string Initials { get; set; }
    }
}
