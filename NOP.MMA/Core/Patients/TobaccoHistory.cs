using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct TobaccoHistory
    {
        bool Smoker { get; set; }
        int AmountPrDay { get; set; }
        DateTime QuitDate { get; set; }
        bool RequestedRehab { get; set; }
    }
}