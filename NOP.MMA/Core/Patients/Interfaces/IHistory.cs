using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public interface IHistory : IPregnancyHistory, IAbortionHistory
    {
    }
}