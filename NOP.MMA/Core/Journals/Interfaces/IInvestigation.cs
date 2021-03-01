using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public interface IInvestigation
    {
        Screening HepB { get; }
        Screening HIV { get; }
        Screening Syphilis { get; }
        Screening Clamydia { get; }
        Screening Gonore { get; }
        Screening Hemoglobinopathy { get; }
        DateTime DVataminReadingDate { get; set; }
        string DVataminReadingResult { get; set; }
    }
}