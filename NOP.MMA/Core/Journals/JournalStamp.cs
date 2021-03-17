using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct JournalStamp
    {
        public DateTime Date { get; set; }
        public string GestationAge { get; set; }
        public double Weight { get; set; }
        public string BloodPressure { get; set; }
        public string UrinSample { get; set; }
        public bool Edema { get; set; }
        //  Symfysefun.mål
        //  Foster-præs.
        public string FetusGender { get; set; }
        public bool FetusActivity { get; set; }
        public string ExaminationLocation { get; set; }
        public string Initials { get; set; }
    }
}
