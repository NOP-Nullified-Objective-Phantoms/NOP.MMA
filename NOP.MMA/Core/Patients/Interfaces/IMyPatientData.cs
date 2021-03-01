using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public interface IPatientData
    {
        string SSN { get; }
        string Name { get; }
        string Address { get; }
        string Email { get; }
        string PrivatePhone { get; }
        string WorkPhone { get; }
        string PrivateGP { get; }
        string DoctorsName { get; }
        string DoctorsAddress { get; }
        string DoctorsPhone { get; }
    }
}