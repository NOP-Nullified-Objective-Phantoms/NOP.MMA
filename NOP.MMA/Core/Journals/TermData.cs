using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct TermData
    {
        public DateTime LastMentruationalDay { get; set; }
        public string MenstruationalCycle { get; set; }
        public DateTime ExpectedBirthDate { get; set; }
        public string Comment { get; set; }
    }
}