using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Can store information about the expected date of birth
    /// </summary>
    public struct TermData
    {
        public TermData ( MenstrualCycleInfo _mentrualInfo, DateTime _expectedBirthDate, string _comment )
        {
            MenstrualInfo = _mentrualInfo;
            ExpectedBirthDate = _expectedBirthDate;
            Comment = _comment;
        }
        public MenstrualCycleInfo MenstrualInfo { get; }
        public DateTime ExpectedBirthDate { get; }
        public string Comment { get; }
    }
}