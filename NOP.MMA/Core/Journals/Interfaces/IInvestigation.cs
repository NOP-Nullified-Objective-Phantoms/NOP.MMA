using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Information about a range of diseases regarding a patient
    /// </summary>
    public interface IInvestigation
    {
        /// <summary>
        /// The result of a HepB <see cref="Screening"/>
        /// </summary>
        Screening HepB { get; }
        /// <summary>
        /// The result of a HIV <see cref="Screening"/>
        /// </summary>
        Screening HIV { get; }
        /// <summary>
        /// The result of a Syphilis <see cref="Screening"/>
        /// </summary>
        Screening Syphilis { get; }
        /// <summary>
        /// The result of a Clamydia <see cref="Screening"/>
        /// </summary>
        Screening Clamydia { get; }
        /// <summary>
        /// The result of a Gonore <see cref="Screening"/>
        /// </summary>
        Screening Gonore { get; }
        /// <summary>
        /// The result of a Hemoglobinopathy <see cref="Screening"/>
        /// </summary>
        Screening Hemoglobinopathy { get; }
        DateTime DVataminReadingDate { get; set; }
        string DVataminReadingResult { get; set; }
    }
}