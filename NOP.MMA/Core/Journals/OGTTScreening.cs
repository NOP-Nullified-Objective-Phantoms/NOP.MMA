using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Contains a set of properties for OGTT screening data
    /// </summary>
    public struct OGTTScreening
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="OGTTScreening"/>
        /// </summary>
        /// <param name="_week18_20"></param>
        /// <param name="_week28_30"></param>
        /// <param name="_glycosuria"></param>
        public OGTTScreening ( JournalData _week18_20, JournalData _week28_30, JournalData _glycosuria )
        {
            Week18_20 = _week18_20;
            Week28_30 = _week28_30;
            Glycosuria = _glycosuria;
        }

        public JournalData Week18_20 { get; }
        public JournalData Week28_30 { get; }

        public JournalData Glycosuria { get; }
    }
}
