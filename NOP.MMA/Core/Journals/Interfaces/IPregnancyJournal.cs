using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents an <see cref="IJournal"/> extended to include information about pregnancies
    /// </summary>
    public interface IPregnancyJournal : IJournal
    {
        /// <summary>
        /// A collection of <see cref="IPatient"/>s former pregnancies
        /// </summary>
        IPregnancyHistory Pregnancies { get; }
        /// <summary>
        /// A collection of <see cref="IPatient"/>s former abortions
        /// </summary>
        IAbortionHistory Abortions { get; }
        /// <summary>
        /// The medical history associated of the <see cref="IPatient"/>, which is associated with the journal
        /// </summary>
        IAnamnese Anamnese { get; }
        /// <summary>
        /// The <see cref="IPatient"/>s desease report
        /// </summary>
        IInvestigation Investegations { get; }
        /// <summary>
        /// A summary of a range of ressource and risk assessements based on the associated <see cref="IAnamnese"/> and <see cref="IInvestigation"/> data
        /// </summary>
        IResourceAndRiskAssessment ResAndRiskAssessement { get; }
    }
}
