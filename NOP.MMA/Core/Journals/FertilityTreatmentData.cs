using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Information about fertility treatment
    /// </summary>
    public struct FertilityTreatmentData
    {
        public FertilityTreatmentData ( bool _recievedFertilityTreatment, string _comment )
        {
            RecievedFertilityTreatment = _recievedFertilityTreatment;
            Comment = _comment;
        }

        public bool RecievedFertilityTreatment { get; }
        public string Comment { get; }
    }
}