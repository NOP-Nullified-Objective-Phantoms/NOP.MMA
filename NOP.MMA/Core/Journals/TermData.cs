﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct TermData
    {
        MenstrualCycleInfo MenstrualInfo { get; }
        public DateTime ExpectedBirthDate { get; set; }
        public string Comment { get; set; }
    }
}