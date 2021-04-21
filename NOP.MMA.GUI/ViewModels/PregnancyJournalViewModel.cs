using NOP.MMA.Core.Journals;
using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.GUI.ViewModels
{
    internal class PregnancyJournalViewModel
    {
        public IPregnancyHistory Pregnancies { get; set; }
        public IAbortionHistory Abortions { get; set; }
        public IAnamnese Anamnese { get; set; }
        public IInvestigation Investegations { get; set; }
        public IResourceAndRiskAssessment ResAndRiskAssessement { get; set; }
        public IPatient PatientData { get; set; }
        public JournalDest JournalDestination { get; set; }
        public int ID { get; set; }
    }
}
