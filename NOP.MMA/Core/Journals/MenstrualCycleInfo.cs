using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Reprensents information about a menstrual cycle
    /// </summary>
    public struct MenstrualCycleInfo
    {
        public DateTime LastMentruationalDay { get; set; }
        public string MenstruationalCycle { get; set; }
        /// <summary>
        /// Whether or not the cycle results are precise
        /// </summary>
        public bool IsCulculationSafe { get; set; }
    }
}
