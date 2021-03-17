using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public interface ITravelerJournal : IJournal
    {
        MenstrualCycleInfo MenstrualInfo { get; }
        DateTime NaegelsRule { get; set; }
        DateTime UltrasoundTermin { get; set; }
        WeightInfo WeightInfo { get; }
        bool MothersRhesusFactor { get; set; }
        bool ChildsRhesusFactor { get; set; }
        Screening HepB { get; }
        bool BloodTypeDetermined { get; set; }
        bool AntibodyByRhesusNegative { get; set; }
        bool IrregularAntibody { get; set; }
        /// <summary>
        /// If <see langword="null"/> the Anti-D Immunoglobulin is not given
        /// </summary>
        JournalData AntiDImmunoglobulinGiven { get; }
        JournalData UrineCulture { get; }
        IReadOnlyList<JournalStamp> JournalStamps { get; }
        IReadOnlyList<JournalComment> JournalComments { get; }
        bool AddJournalStamp ( JournalStamp _stamp );
        bool RemoveJournalStamp ( DateTime _stampDate );
        bool AddJournalSComment ( JournalComment _comment );
        bool RemoveJournalComment ( DateTime _commentDate );
    }
}
