using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct TobaccoHistory
    {
        public bool Smoker { get; set; }
        public int AmountPrDay { get; set; }
        public DateTime QuitDate { get; set; }
        public bool RequestedRehab { get; set; }
    }
}