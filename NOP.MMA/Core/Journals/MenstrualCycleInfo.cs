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
        public MenstrualCycleInfo ( DateTime _lastMensstrualDay, string _menstrualCycle, bool _isCalculationSafe )
        {
            LastMentruationalDay = _lastMensstrualDay;
            MenstruationalCycle = _menstrualCycle;
            IsCalculationSafe = _isCalculationSafe;
        }

        public DateTime LastMentruationalDay { get; }
        public string MenstruationalCycle { get; }
        /// <summary>
        /// Whether or not the cycle results are precise
        /// </summary>
        public bool IsCalculationSafe { get; }
    }
}
