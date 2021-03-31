using NOP.Common.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public static class PatientHelper
    {
        public static IPatientData GetPatientData ()
        {
            return new PatientData ()
            {
                Address = "MyAddress",
                DoctorsAddress = "MyDoctersAddress",
                DoctorsName = "MyDoctorsName",
                DoctorsPhone = "MyDoctorsPhone",
                Email = "MyEmail",
                Name = "MyName",
                PrivateGP = "MyPrivateGeneralPractitioner",
                PrivatePhone = "MyPrivatePhone",
                SSN = "MySocialSecurityNumber",
                WorkPhone = "MyWorkPhone"
            };
        }

        public static IPatientSocialData GetSocialData ()
        {
            return new PatientSocialData ()
            {
                ChildFathersName = "MyChildsFathersName",
                ChildFathersSSN = "MyChildsFathersSocialSecurityNumber",
                CivilStatus = MaritalStatus.Married,
                Cohibitable = true,
                Nationality = "MyNationality",
                NeedTranslator = false,
                OtherInfo = "MyOtherInfo",
                TranslatorLanguage = "None"
            };
        }

        public static void ManualStorageInsertion (IPatient _patient, string _path)
        {
            FileHandler file = new FileHandler (_path);
            file.Write (_patient.SaveEntity ());
        }

        public static bool CheckIDFromStorage (int _expectedID, string _path)
        {
            FileHandler file = new FileHandler (_path);
            if (int.TryParse (file.FindLine ($"PatientID{_expectedID}").Split (",")[ 0 ]?.Replace ("PatientID", string.Empty), out int _id) )
            {
                return ( _id == _expectedID );
            }

            return false;
        }

        public static bool CheckValueFromStorage (string _expectedValue, string _path )
        {
            FileHandler file = new FileHandler (_path);
            return file.FindLine (_expectedValue) != null;
        }
    }
}
