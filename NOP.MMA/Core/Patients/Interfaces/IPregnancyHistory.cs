using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Represents a collection of <see cref="IPregnancyHistoryEntry"/> <see langword="objects"/>
    /// </summary>
    public interface IPregnancyHistory : IHistory <IPregnancyHistoryEntry>
    {
    }
}