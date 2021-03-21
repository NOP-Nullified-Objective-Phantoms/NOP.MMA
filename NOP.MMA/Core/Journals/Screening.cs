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
        public DateTime Date { get; set; }
        public ScreeningInfo Result { get; set; }
    }
}