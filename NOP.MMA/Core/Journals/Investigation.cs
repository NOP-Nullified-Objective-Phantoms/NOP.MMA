using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents a report of a range of diseases
    /// </summary>
    internal class Investigation : IInvestigation
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="Investigation"/> with its <see langword="default"/> values
        /// </summary>
        public Investigation ()
        {
            HepB = new Screening ();
            HIV = new Screening ();
            Syphilis = new Screening ();
            Clamydia = new Screening ();
            Gonore = new Screening ();
            Hemoglobinopathy = new Screening ();
        }

        public Screening HepB { get; }
        public Screening HIV { get; }
        public Screening Syphilis { get; }
        public Screening Clamydia { get; }
        public Screening Gonore { get; }
        public Screening Hemoglobinopathy { get; }
        public DateTime DVataminReadingDate { get; set; }
        public string DVataminReadingResult { get; set; }
    }
}
