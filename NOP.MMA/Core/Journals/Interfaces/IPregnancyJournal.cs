using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    interface IPregnancyJournal : IJournal
    {
        IPregnancyHistory Pregnancies { get; }
        IAbortionHistory Abortions { get; }
        IAnamnese Anamnsese { get; }
        IInvestigation Investegations { get; }
        IResourceAndRiskAssessment ResAndRiskAssessement { get; }
    }
}
