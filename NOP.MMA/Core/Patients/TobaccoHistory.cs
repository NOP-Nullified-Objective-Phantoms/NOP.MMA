using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public struct TobaccoHistory
    {
        public TobaccoHistory ( bool _smoker, int _amountPrDay, DateTime _quitDate, bool _requestedRehab )
        {
            Smoker = _smoker;
            AmountPrDay = _amountPrDay;
            QuitDate = _quitDate;
            RequestedRehab = _requestedRehab;
        }
        public bool Smoker { get; }
        public int AmountPrDay { get; }
        public DateTime QuitDate { get; }
        public bool RequestedRehab { get; }
    }
}