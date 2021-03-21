using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Information about the assessement of prenatal risk
    /// </summary>
    public struct PrenatalRiskAssessment
    {
        public string FamiliyHistory { get; set; }
        public bool DoubleTestTaken { get; set; }
        public bool TripleTestTaken { get; set; }
        public bool RequestedNuchalFoldScan { get; set; }
        public bool RequestedMalformationScan { get; set; }
    }
}