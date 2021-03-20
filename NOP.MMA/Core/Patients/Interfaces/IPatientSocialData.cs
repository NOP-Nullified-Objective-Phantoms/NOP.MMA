using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Defines a set of social data for a medical patient
    /// </summary>
    public interface IPatientSocialData
    {
        MaritalStatus CivilStatus { get; set; }
        /// <summary>
        /// Whether the patient lives with someone or not
        /// </summary>
        bool Cohibitable { get; set; }
        string ChildFathersName { get; set; }
        string ChildFathersSSN { get; set; }
        bool NeedTranslator { get; set; }
        string TranslatorLanguage { get; set; }
        string Nationality { get; set; }
        string OtherInfo { get; set; }
    }
}