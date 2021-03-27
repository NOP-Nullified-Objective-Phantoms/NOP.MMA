using NOP.MMA.Core.Journals;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Information about a patients allergies
    /// </summary>
    public struct AllergyAssessement
    {
        public AllergyAssessement ( string _allergies, ChildDisposedAllergy _disposedAllergy )
        {
            Allergies = _allergies;
            ChildAllergyRisk = _disposedAllergy;
        }

        public string Allergies { get; }
        public ChildDisposedAllergy ChildAllergyRisk { get; }
    }
}