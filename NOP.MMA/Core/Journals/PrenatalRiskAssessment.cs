using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct PrenatalRiskAssessment
    {
        public string FamiliyHistory { get; set; }
        public bool DoubleTestTaken { get; set; }
        public bool TripleTestTaken { get; set; }
        public bool RequestedNuchalFoldScan { get; set; }
        public bool RequestedMalformationScan { get; set; }
    }
}