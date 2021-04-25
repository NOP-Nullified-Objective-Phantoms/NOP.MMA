using NOP.MMA.Core.Journals;
using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.GUI.ViewModels
{
    internal class TravelerJournalViewModel
    {
        public MenstrualCycleInfo MenstrualInfo { get; set; }
        public DateTime NaegelsRule { get; set; }
        public DateTime UltrasoundTermin { get; set; }
        public WeightInfo WeightInfo { get; set; }
        public bool MothersRhesusFactor { get; set; }
        public bool ChildsRhesusFactor { get; set; }
        public Screening HepB { get; set; }
        public bool BloodTypeDetermined { get; set; }
        public bool AntibodyByRhesusNegative { get; set; }
        public bool IrregularAntibody { get; set; }
        /// <summary>
        /// If <see langword="null"/> the Anti-D Immunoglobulin is not given
        /// </summary>
        public JournalData AntiDImmunoglobulinGiven { get; set; }
        /// <summary>
        /// <see langword="Null"/> if <see langword="false"/>; Otherwise, if <see langword="true"/>, not <see langword="null"/>
        /// </summary>
        public JournalData UrineCulture { get; set; }
        public IReadOnlyList<JournalStamp> JournalStamps { get; set; }
        public IReadOnlyList<JournalComment> JournalComments { get; set; }
        public IReadOnlyList<UltrasoundResult> UltraSoundScans { get; set; }
        public DateTime NuchalFoldScan { get; set; }
        public DateTime DoubleTest { get; set; }
        public DateTime TripleTest { get; set; }
        public JournalData OddsForDS { get; set; }
        public JournalData PlacentaTest { get; set; }
        public JournalData AmnioticFluidTest { get; set; }
        public OGTTScreening OralGlukoseToleranceTest { get; set; }
        public string AdditonalContext { get; set; }
        public BirthplaceInformation BirthplaceInfo { get; set; }
        public IPatient PatientData { get; set; }
        public JournalDest JournalDestination { get; set; }
        public int ID { get; set; }
    }
}
