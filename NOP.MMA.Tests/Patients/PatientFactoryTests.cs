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
            bool notNull;
            bool correctID;
            IPatient patient;

            //  Act
            patient = PatientFactory.CreateEmpty ();
            notNull = patient != null;
            correctID = patient.ID == expectedID;

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {( ( notNull ) ? ( patient.ID.ToString () ) : ( "NaN" ) )} | Expected: {expectedID}}}");
        }

        [Fact]
        public void CanCreateWithID ()
        {
            //  Arrange
            int expectedID = currentIDIndex;
            bool notNull;
            bool correctID;
            IPatient patient;

            //  Act
            patient = PatientFactory.Create ();
            notNull = patient != null;
            correctID = patient.ID == expectedID;

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {( ( notNull ) ? ( patient.ID.ToString () ) : ( "NaN" ) )} | Expected: {expectedID}}}");

            currentIDIndex++;   //  Incrementing the ID index in case another patient is created after this test
        }

        [Fact]
        public void CanCreateFromData ()
        {
            //  Arrange
            int expectedID = currentIDIndex;
            bool notNull;
            bool correctID;
            IPatient patient;

            //  Act
            patient = PatientFactory.Create (PatientHelper.GetPatientData (), PatientHelper.GetSocialData ());
            notNull = patient != null;
            correctID = patient.ID == expectedID;

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {( ( notNull ) ? ( patient.ID.ToString () ) : ( "NaN" ) )} | Expected: {expectedID}}}");

            currentIDIndex++;   //  Incrementing the ID index in case another patient is created after this test
        }
    }
}
