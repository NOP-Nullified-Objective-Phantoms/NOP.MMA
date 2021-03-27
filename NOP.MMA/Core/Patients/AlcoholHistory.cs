using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct AlcoholHistory
    {
        public AlcoholHistory ( bool _duringPregnancy, int _amountPrWeek, bool _multiplePrSession )
        {
            DuringPregnancy = _duringPregnancy;
            AmountPrWeek = _amountPrWeek;
            MultiplePrSession = _multiplePrSession;
        }

        public bool DuringPregnancy { get; }
        public int AmountPrWeek { get; }
        public bool MultiplePrSession { get; }
    }
}