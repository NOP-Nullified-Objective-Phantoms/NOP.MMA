using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// A set of flags to determine where a <see cref="IJournal"/> is destinated for
    /// </summary>
    public enum JournalDest
    {
        ToPregnant,
        ToMidwife,
        ToPlaceOfBirth,
        ToDoctor
    }
}