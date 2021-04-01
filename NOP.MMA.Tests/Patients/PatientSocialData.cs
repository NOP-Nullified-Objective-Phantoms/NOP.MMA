using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    internal class PatientSocialData : IPatientSocialData
    {
        public MaritalStatus CivilStatus { get; set; }
        public bool Cohibitable { get; set; }
        public string ChildFathersName { get; set; }
        public string ChildFathersSSN { get; set; }
        public bool NeedTranslator { get; set; }
        public string TranslatorLanguage { get; set; }
        public string Nationality { get; set; }
        public string OtherInfo { get; set; }
    }
}
