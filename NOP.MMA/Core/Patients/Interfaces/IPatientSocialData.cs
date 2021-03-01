using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public interface IPatientSocialData
    {
        bool MaritalStatus { get; set; }
        bool Cohibitable { get; set; }
        string ChildFathersName { get; set; }
        string ChildFathersSSN { get; set; }
        bool NeedTranslator { get; set; }
        string TranslatorLanguage { get; set; }
        string Nationality { get; set; }
        string OtherInfo { get; set; }
    }
}