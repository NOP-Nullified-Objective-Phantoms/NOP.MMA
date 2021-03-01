using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct ChronicMedicalHistory
    {
        bool Circulation { get; set; }
        bool Airways { get; set; }
        bool Thyroidea { get; set; }
        bool Diabetes { get; set; }
        bool Epilepsy { get; set; }
        bool PsychologicalIllness { get; set; }
        bool HerpesGenitalis { get; set; }
        bool RecurrentUTI { get; set; }
    }
}