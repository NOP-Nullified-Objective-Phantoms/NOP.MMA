using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct ChronicMedicalHistory
    {
        public bool Circulation { get; set; }
        public bool Airways { get; set; }
        public bool Thyroidea { get; set; }
        public bool Diabetes { get; set; }
        public bool Epilepsy { get; set; }
        public bool PsychologicalIllness { get; set; }
        public bool HerpesGenitalis { get; set; }
        public bool RecurrentUTI { get; set; }
    }
}