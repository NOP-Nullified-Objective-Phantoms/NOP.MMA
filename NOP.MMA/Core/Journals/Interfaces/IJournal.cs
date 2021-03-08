using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public interface IJournal
    {
        IPatient PatientData { get; }
        JournalDest JournalDestination { get; }
    }
}