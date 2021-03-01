using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public interface IJournal
    {
        IPatient PatientData { get; }
        IHistory PatientHistory { get; }
        IAnamnese Anamnsese { get; }
        IInvestigation Investegations { get; }
        IResourceAndRiskAssessment ResAndRiskAssessement { get; }
        JournalDest JournalDestination { get; }
    }
}