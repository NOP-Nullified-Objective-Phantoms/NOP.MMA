using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NOP.Common.Files;
using NOP.Common.Repository;
using NOP.MMA.Core.Patients;
using Xunit;

namespace NOP.MMA.Repository
{
    public class PatientRepoTests
    {
        public PatientRepoTests ()
        {
            patient = PatientFactory.Create (PatientHelper.GetPatientData (), PatientHelper.GetSocialData ());
            currentIDIndex++;   //  Incrementing the ID index in case another patient is created after this test
        }

        ~PatientRepoTests ()
        {
            if ( Directory.Exists (PatientRepo.Link.StoragePath) )
            {
                Directory.Delete (PatientRepo.Link.StoragePath, true);
            }
        }

        private static int currentIDIndex = 0;
        private readonly IPatient patient;

        [Fact]
        public void A_CanInsertPatient ()
        {
            //  Arrange
            int expectedID;
            bool didInsert;
            bool ensuredInsertion;

            //  Act
            expectedID = currentIDIndex;
            didInsert = PatientRepo.Link.InsertData (patient);

            ensuredInsertion = PatientHelper.CheckIDFromStorage (expectedID, PatientRepo.Link.FullPath);

            //  Assert
            Assert.True (didInsert && ensuredInsertion, $"{AssertHelper.ValidatorMessage ("Did Insert:", didInsert, didInsert, true)} <|> {AssertHelper.ValidatorMessage ("Ensured Insertion:", ensuredInsertion, patient.ID, expectedID)}");
        }

        [Fact]
        public void CanGetByID ()
        {
            //  Arrange
            int expectedID;
            IPatient retrievedPatient;
            bool notNull;
            bool correctID;
            PatientHelper.ManualStorageInsertion (patient, PatientRepo.Link.FullPath);  //  Ensuring that an entry exists in storage

            //  Act
            expectedID = patient.ID;
            retrievedPatient = PatientRepo.Link.GetDataByIdentifier (patient.ID);
            notNull = ( retrievedPatient != null );
            correctID = ( retrievedPatient?.ID == expectedID );

            //  Assert
            Assert.True (notNull && correctID, $"{AssertHelper.ValidatorMessage ("Is Null:", !notNull, !notNull, false)} <|> {AssertHelper.ValidatorMessage ("Correct ID:", correctID, ( ( !notNull ) ? ( retrievedPatient.ID.ToString () ) : ( "NaN" ) ), expectedID)}");
        }

        [Fact]
        public void CanUpdatePatient ()
        {
            //  Arrange
            bool updated;
            bool validated;
            string orignalValue = patient.ChildFathersName;
            PatientHelper.ManualStorageInsertion (patient, PatientRepo.Link.FullPath);

            //  Act

            patient.ChildFathersName = "MyChangedChildFathersName";
            updated = PatientRepo.Link.UpdateData (patient);
            validated = PatientHelper.CheckValueFromStorage (patient.ChildFathersName, PatientRepo.Link.FullPath);
            patient.ChildFathersName = orignalValue;

            //  Asserts
            Assert.True (updated && validated, $"{AssertHelper.ValidatorMessage ("Updated:", updated, updated, true)} <|> {AssertHelper.ValidatorMessage ("Validated:", validated, validated, true)}");
        }

        [Fact]
        public void CanDeletePatient ()
        {
            //  Arrange
            int expectedID = currentIDIndex;
            bool didDelete;
            bool wasNull;
            PatientHelper.ManualStorageInsertion (patient, PatientRepo.Link.FullPath);

            //  Act
            didDelete = PatientRepo.Link.DeleteData (patient);
            wasNull = !PatientHelper.CheckIDFromStorage (expectedID, PatientRepo.Link.FullPath);

            //  Assert
            Assert.True (didDelete && wasNull, $"{AssertHelper.ValidatorMessage ("Did Delete:", didDelete, didDelete, true)} <|> {AssertHelper.ValidatorMessage ("Was Null:", wasNull, wasNull, true)}");
        }

        [Fact]
        public void CanGetEnumerator ()
        {
            //  Arrange
            int expectedEntries = 3;
            bool notNull;
            bool notEmpty;
            bool correctAmount;
            PatientHelper.ManualStorageInsertion (PatientHelper.GetNewPatient (), PatientRepo.Link.FullPath);
            PatientHelper.ManualStorageInsertion (PatientHelper.GetNewPatient (), PatientRepo.Link.FullPath, true);
            PatientHelper.ManualStorageInsertion (PatientHelper.GetNewPatient (), PatientRepo.Link.FullPath, true);

            //  Act
            List<IPatient> patients = PatientRepo.Link.GetEnumerable ().ToList ();
            notNull = patient != null;
            notEmpty = patients?.Count != 0;
            correctAmount = patients?.Count == 3;

            //  Assert
            Assert.True (notNull && notEmpty && correctAmount, $" {AssertHelper.ValidatorMessage ("Is Null:", !notNull, !notNull, false)} <|> {AssertHelper.ValidatorMessage ("Is Empty:", !notEmpty, ( ( patient != null ) ? ( patients.Count.ToString () ) : ( "NaN" ) ), "> 0")} <|> {AssertHelper.ValidatorMessage ("Correct Amount:", correctAmount, ( ( patients != null ) ? ( patients.Count.ToString () ) : ( "NaN" ) ), expectedEntries)}");

            currentIDIndex++;   //  Incrementing the ID index in case another patient is created after this test
            currentIDIndex++;   //  Incrementing the ID index in case another patient is created after this test
            currentIDIndex++;   //  Incrementing the ID index in case another patient is created after this test
        }
    }
}
