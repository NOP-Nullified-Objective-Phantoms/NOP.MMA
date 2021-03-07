using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct AlcoholHistory
    {
        public bool DuringPregnancy { get; set; }
        public int AmountPrWeek { get; set; }
        public bool MultiplePrSession { get; set; }
    }
}