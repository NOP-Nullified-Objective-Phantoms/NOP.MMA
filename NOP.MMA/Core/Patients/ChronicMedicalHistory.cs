using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Information about a patients medical history regarding chronic health issues
    /// </summary>
    public struct ChronicMedicalHistory
    {
        public ChronicMedicalHistory ( bool _circulation, bool _airways, bool _thyroidea, bool _diabetes, bool _epilepsy, bool _psychologicalIllness, bool _herpesGenitalis, bool _recurrentUTI )
        {
            Circulation = _circulation;
            Airways = _airways;
            Thyroidea = _thyroidea;
            Diabetes = _diabetes;
            Epilepsy = _epilepsy;
            PsychologicalIllness = _psychologicalIllness;
            HerpesGenitalis = _herpesGenitalis;
            RecurrentUTI = _recurrentUTI;
        }
        public bool Circulation { get; }
        public bool Airways { get; }
        public bool Thyroidea { get; }
        public bool Diabetes { get; }
        public bool Epilepsy { get; }
        public bool PsychologicalIllness { get; }
        public bool HerpesGenitalis { get; }
        public bool RecurrentUTI { get; }
    }
}