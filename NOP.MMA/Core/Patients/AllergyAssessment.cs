using NOP.MMA.Core.Journals;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Information about a patients allergies
    /// </summary>
    public struct AllergyAssessment
    {
        public string Allergies { get; set; }
        public ChildDisposedAllergy ChildAllergyRisk { get; set; }
    }
}