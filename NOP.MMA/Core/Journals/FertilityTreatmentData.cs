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
        public bool RecievedFertilityTreatment { get; set; }
        public string Comment { get; set; }
    }
}