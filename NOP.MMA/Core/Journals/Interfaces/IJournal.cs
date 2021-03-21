using NOP.Common.Repository;
using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents a journal with data about the associated <see cref="IPatient"/> and the destination of the journal
    /// </summary>
    public interface IJournal : IRepositoryEntity<int, string>
    {
        /// <summary>
        /// The data  of the associated patient
        /// </summary>
        IPatient PatientData { get; }
        /// <summary>
        /// The information that defines where the journal should be sent to
        /// </summary>
        JournalDest JournalDestination { get; }
    }
}