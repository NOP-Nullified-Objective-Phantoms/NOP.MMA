using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct AllergyAssessment
    {
        public string Allergies { get; set; }
        public ChildDisposedAllergy ChildAllergyRisk { get; set; }
    }
}