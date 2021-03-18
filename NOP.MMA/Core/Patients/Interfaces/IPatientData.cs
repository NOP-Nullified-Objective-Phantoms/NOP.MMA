using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Defines a set of data associated with a medical patient
    /// </summary>
    public interface IPatientData
    {
        /// <summary>
        /// The social security number for the patient
        /// </summary>
        string SSN { get; }
        string Name { get; }
        string Address { get; }
        string Email { get; }
        string PrivatePhone { get; }
        string WorkPhone { get; }
        /// <summary>
        /// The patients General practitioner
        /// </summary>
        string PrivateGP { get; }
        string DoctorsName { get; }
        string DoctorsAddress { get; }
        string DoctorsPhone { get; }
    }
}