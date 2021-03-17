using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct MenstrualCycleInfo
    {
        public DateTime LastMentruationalDay { get; set; }
        public string MenstruationalCycle { get; set; }
        public bool IsCulculationSafe { get; set; }
    }
}
