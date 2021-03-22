using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Defines a screening with date and result
    /// </summary>
    public struct Screening
    {
        public Screening ( DateTime _date, ScreeningInfo _result )
        {
            Date = _date;
            Result = _result;
        }

        public DateTime Date { get; }
        public ScreeningInfo Result { get; }
    }
}