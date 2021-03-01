using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct Screening
    {
        DateTime Date { get; set; }
        ScreeningInfo Result { get; set; }
    }
}