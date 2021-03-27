using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Represents a collection of <see cref="IAbortionHistory"/> <see langword="objects"/>
    /// </summary>
    internal class AbortionHistory : IAbortionHistory
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="AbortionHistory"/> with its <see langword="default"/> values
        /// </summary>
        public AbortionHistory ()
        {
            history = new List<IAbortionHistoryEntry> ();
        }

        private readonly List<IAbortionHistoryEntry> history = null;
        public IReadOnlyList<IAbortionHistoryEntry> History { get; }
        public IAbortionHistoryEntry this[ int _index ]
        {
            get
            {
                return history[ _index ];
            }
        }

        public void AddHistory ( IAbortionHistoryEntry _entry )
        {
            history.Add (_entry);
        }

        public void RemoveHistory ( IAbortionHistoryEntry _entry )
        {
            history.Remove (_entry);
        }
    }
}
