using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    internal class PatientData : IPatientData
    {
        public string SSN { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PrivatePhone { get; set; }
        public string WorkPhone { get; set; }
        public string PrivateGP { get; set; }
        public string DoctorsName { get; set; }
        public string DoctorsAddress { get; set; }
        public string DoctorsPhone { get; set; }
    }
}
