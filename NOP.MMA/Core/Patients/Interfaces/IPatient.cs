using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{

    /// <summary>
    /// Defines a medical patient with associated data
    /// </summary>
    public interface IPatient : IPatientData, IPatientSocialData
    {
    }
}