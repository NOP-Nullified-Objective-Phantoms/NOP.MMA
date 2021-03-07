using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct Screening
    {
        public DateTime Date { get; set; }
        public ScreeningInfo Result { get; set; }
    }
}