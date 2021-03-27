using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public static class JournalFactory
    {
        /// <summary>
        /// Creates a new empty <see cref="IJournal"/> <see langword="object"/> that does not increment the ID counter (<strong><i>Note: The ID must be set(Changed) after creation, as the <see cref="object"/> is initialized with an ID of zero</i></strong>)
        /// </summary>
        /// <param name="_type">The type of <see cref="IJournal"/> to be created</param>
        /// <returns>A new instance of type <see cref="IJournal"/> where the ID is set to zero.</returns>
        public static IJournal CreateEmpty ( JournalType _type )
        {
            return _type switch
            {
                JournalType.PregnancyJournal => new PregnancyJournal (0),
                JournalType.TravelerJournal => null,
                _ => null,
            };
        }

        /// <summary>
        /// Create a new <see cref="IJournal"/> <see langword="object"/>
        /// </summary>
        /// <param name="_type">The type of <see cref="IJournal"/> to be created</param>
        /// <returns>A new empty <see cref="IJournal"/> <see langword="object"/> that increments the ID counter</returns>
        public static IJournal Create ( JournalType _type )
        {
            return _type switch
            {
                JournalType.PregnancyJournal => null,
                JournalType.TravelerJournal => null,
                _ => null,
            };
        }

        /// <summary>
        /// Creates a new <see cref="IJournal"/> <see langword="object"/> based on an associated <see cref="IPatient"/>
        /// </summary>
        /// <param name="_type">The type of <see cref="IJournal"/> to be created</param>
        /// <param name="_patient">The associated <see cref="IPatient"/> <see langword="object"/></param>
        /// <returns>A new populated <see cref="IJournal"/> <see langword="object"/> that increments the ID counter</returns>
        public static IJournal CreateWithPatient ( JournalType _type, IPatient _patient )
        {
            return _type switch
            {
                JournalType.PregnancyJournal => new PregnancyJournal ()
                {
                    PatientData = _patient
                },
                JournalType.TravelerJournal => null,
                _ => null,
            };
        }
    }
}
