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
        public PrenatalRiskAssessment ( string _familiyHistory, bool _doubleTest, bool _tripleTest, bool _requestedNuchalFoldScan, bool _requestedMalformationScan )
        {
            FamiliyHistory = _familiyHistory;
            DoubleTestTaken = _doubleTest;
            TripleTestTaken = _tripleTest;
            RequestedNuchalFoldScan = _requestedNuchalFoldScan;
            RequestedMalformationScan = _requestedMalformationScan;
        }

        public string FamiliyHistory { get; }
        public bool DoubleTestTaken { get; }
        public bool TripleTestTaken { get; }
        public bool RequestedNuchalFoldScan { get; }
        public bool RequestedMalformationScan { get; }
    }
}