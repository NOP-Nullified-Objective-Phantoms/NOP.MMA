using System;
using Xunit;

namespace NOP.MMA.Core.Patients
{
    public class PatientFactoryTests
    {
        private static int currentIDIndex = 1;  //  Keep track of the amount of patients that are created during the tests

        [Fact]
        public void CanCreateEmpty ()
        {
            //  Arrange
            int expectedID = 0;
            IPatient patient;

            //  Act
            patient = PatientFactory.CreateEmpty ();
            bool notNull = patient != null;
            bool correctID = patient.ID == expectedID;

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {( ( notNull ) ? ( patient.ID.ToString () ) : ( "NaN" ) )} | Expected: {expectedID}}}");
        }

        [Fact]
        public void CanCreateWithID ()
        {
            //  Arrange
            int expectedID = currentIDIndex;
            IPatient patient;

            //  Act
            patient = PatientFactory.Create ();
            bool notNull = patient != null;
            bool correctID = patient.ID == expectedID;

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {( ( notNull ) ? ( patient.ID.ToString () ) : ( "NaN" ) )} | Expected: {expectedID}}}");

            currentIDIndex++;   //  Incrementing the ID index in case another patient is created after this test
        }

        [Fact]
        public void CanCreateFromData ()
        {
            //  Arrange
            int expectedID = currentIDIndex;
            IPatient patient;
            IPatientData pData;
            IPatientSocialData pSocialData;

            //  Act
            #region Establishing Test Data
            pData = new PatientData ()
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

            pSocialData = new PatientSocialData ()
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
            #endregion

            patient = PatientFactory.Create (pData, pSocialData);
            bool notNull = patient != null;
            bool correctID = patient.ID == expectedID;

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {((notNull)?(patient.ID.ToString()):("NaN"))} | Expected: {expectedID}}}");

            currentIDIndex++;   //  Incrementing the ID index in case another patient is created after this test
        }
    }

    #region Test Classes
    class PatientData : IPatientData
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

    class PatientSocialData : IPatientSocialData
    {
        public MaritalStatus CivilStatus { get; set; }
        public bool Cohibitable { get; set; }
        public string ChildFathersName { get; set; }
        public string ChildFathersSSN { get; set; }
        public bool NeedTranslator { get; set; }
        public string TranslatorLanguage { get; set; }
        public string Nationality { get; set; }
        public string OtherInfo { get; set; }
    }
    #endregion
}
