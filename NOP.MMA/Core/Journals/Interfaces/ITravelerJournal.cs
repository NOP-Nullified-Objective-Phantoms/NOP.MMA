using System;
using System.Collections.Generic;
using System.Text;
using NOP.MMA.Core.Patients;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents an <see cref="IJournal"/> extended to include information about an <see cref="IPatient"/>s progression through a pregnancy
    /// </summary>
    public interface ITravelerJournal : IJournal
    {
        MenstrualCycleInfo MenstrualInfo { get; set; }
        DateTime NaegelsRule { get; set; }
        DateTime UltrasoundTermin { get; set; }
        WeightInfo WeightInfo { get; set; }
        bool MothersRhesusFactor { get; set; }
        bool ChildsRhesusFactor { get; set; }
        Screening HepB { get; set; }
        bool BloodTypeDetermined { get; set; }
        bool AntibodyByRhesusNegative { get; set; }
        bool IrregularAntibody { get; set; }
        /// <summary>
        /// If <see langword="null"/> the Anti-D Immunoglobulin is not given
        /// </summary>
        JournalData AntiDImmunoglobulinGiven { get; set; }
        /// <summary>
        /// <see langword="Null"/> if <see langword="false"/>; Otherwise, if <see langword="true"/>, not <see langword="null"/>
        /// </summary>
        JournalData UrineCulture { get; set; }
        IReadOnlyList<JournalStamp> JournalStamps { get; }
        IReadOnlyList<JournalComment> JournalComments { get; }
        IReadOnlyList<UltrasoundResult> UltraSoundScans { get; }
        bool AddJournalStamp ( JournalStamp _stamp );
        bool RemoveJournalStamp ( DateTime _stampDate );
        bool AddJournalComment ( JournalComment _comment );
        bool RemoveJournalComment ( DateTime _commentDate );
        bool AddUltraSoundScan ( UltrasoundResult _scan );
        bool RemoveUltrasoundScan ( DateTime _scanDate );
        DateTime NuchalFoldScan { get; set; }
        DateTime DoubleTest { get; set; }
        DateTime TripleTest { get; set; }
        /// <summary>
        /// DS = Downsyndrom
        /// </summary>
        JournalData OddsForDS { get; set; }
        JournalData PlacentaTest { get; set; }
        JournalData AmnioticFluidTest { get; set; }
        OGTTScreening OralGlukoseToleranceTest { get; set; }
        string AdditonalContext { get; set; }
        BirthplaceInformation BirthplaceInfo { get; set; }
    }
}
