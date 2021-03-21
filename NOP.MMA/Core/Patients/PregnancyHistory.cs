using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Represents a collection of <see cref="IPregnancyHistoryEntry"/> <see langword="objects"/>
    /// </summary>
    internal class PregnancyHistory : IPregnancyHistory
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="PregnancyHistory"/> with its <see langword="default"/> values
        /// </summary>
        public PregnancyHistory ()
        {
            history = new List<IPregnancyHistoryEntry> ();
        }

        private readonly List<IPregnancyHistoryEntry> history = null;
        public IReadOnlyList<IPregnancyHistoryEntry> History { get; }
        public IPregnancyHistoryEntry this[ int _index ]
        {
            get
            {
                return history[ _index ];
            }
        }

        public void AddHistory ( IPregnancyHistoryEntry _entry )
        {
            history.Add (_entry);
        }

        public void RemoveHistory ( IPregnancyHistoryEntry _entry )
        {
            history.Remove (_entry);
        }
    }
}
