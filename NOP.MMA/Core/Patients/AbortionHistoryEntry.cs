using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// A history record of an abortion
    /// </summary>
    public class AbortionHistoryEntry : IAbortionHistory
    {
        public IAbortionHistoryEntry this[ int _index ]
        {
            get
            {
                return history[ _index ];
            }
        }

        private List<IAbortionHistoryEntry> history = null;
        public IReadOnlyList<IAbortionHistoryEntry> History
        {
            get
            {
                return history;
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
