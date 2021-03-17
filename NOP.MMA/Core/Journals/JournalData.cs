using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct JournalData
    {
        public bool IsPositive { get; set; }
        public DateTime Date { get; set; }
        public string Intials { get; }
    }
}
