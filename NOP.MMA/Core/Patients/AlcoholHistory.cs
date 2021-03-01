using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct AlcoholHistory
    {
        bool DuringPregnancy { get; set; }
        int AmountPrWeek { get; set; }
        bool MultiplePrSession { get; set; }
    }
}