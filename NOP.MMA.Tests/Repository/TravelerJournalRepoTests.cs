using NOP.MMA.Core.Journals;
using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace NOP.MMA.Repository
{
    public class TravelerJournalRepoTests
    {
        private static int currentIDIndex;
        private ITravelerJournal journal;
        private IPatient patient;

        [Fact]
        public void A_CanInsertTravelerJournal ()
        {
            //  Arrange
            Initiate ();
            int expectedID;
            bool didInsert;
            bool ensuredInsertion;

            //  Act
            expectedID = currentIDIndex;
            didInsert = TravelerJournalRepo.Link.InsertData (journal);
            ensuredInsertion = JournalHelper.CheckIDFromStorage (expectedID, TravelerJournalRepo.Link.FilePath);
            CleanUp ();

            //  Assert
            Assert.True (didInsert && ensuredInsertion, $"{AssertHelper.ValidatorMessage ("Did Insert:", didInsert, didInsert, true)} <|> {AssertHelper.ValidatorMessage ("Ensured Insertion:", ensuredInsertion, journal.ID, expectedID)}");
        }

        [Fact]
        public void CanGetByID ()
        {
            //  Arrange
            Initiate ();
            int expectedID;
            ITravelerJournal retrievedJournal;
            bool notNull;
            bool correctID;
            JournalHelper.ManualStorageInsertion (journal, JournalType.TravelerJournal, TravelerJournalRepo.Link.StoragePath);  //  Ensuring that an entry exists in storage

            //  Act
            expectedID = journal.ID;
            retrievedJournal = TravelerJournalRepo.Link.GetDataByIdentifier (journal.ID);
            notNull = ( retrievedJournal != null );
            correctID = ( retrievedJournal?.ID == expectedID );
            CleanUp ();

            //  Assert
            Assert.True (notNull && correctID, $"{AssertHelper.ValidatorMessage ("Is Null:", !notNull, !notNull, false)} <|> {AssertHelper.ValidatorMessage ("Correct ID:", correctID, ( ( notNull ) ? ( retrievedJournal.ID.ToString () ) : ( "NaN" ) ), expectedID)}");
        }

        [Fact]
        public void CanUpdateTravelerJournal ()
        {
            //  Arrange
            Initiate ();
            bool updated;
            bool validated;
            string orignalValue = journal.PatientData.ChildFathersName;
            JournalHelper.ManualStorageInsertion (journal, JournalType.TravelerJournal, TravelerJournalRepo.Link.StoragePath);
            PatientHelper.ManualStorageInsertion (patient, PatientRepo.Link.FullPath);

            //  Act
            journal.PatientData.ChildFathersName = "MyChangedChildFathersName";
            updated = TravelerJournalRepo.Link.UpdateData (journal);
            validated = PatientHelper.CheckValueFromStorage (journal.PatientData.ChildFathersName, PatientRepo.Link.FullPath);
            journal.PatientData.ChildFathersName = orignalValue;
            CleanUp ();

            //  Asserts
            Assert.True (updated && validated, $"{AssertHelper.ValidatorMessage ("Updated:", updated, updated, true)} <|> {AssertHelper.ValidatorMessage ("Validated:", validated, validated, true)}");
        }

        [Fact]
        public void CanDeleteTravelerJournal ()
        {
            //  Arrange
            Initiate ();
            int expectedID = currentIDIndex;
            bool didDelete;
            bool wasNull;
            JournalHelper.ManualStorageInsertion (journal, JournalType.TravelerJournal, TravelerJournalRepo.Link.StoragePath);

            //  Act
            didDelete = TravelerJournalRepo.Link.DeleteData (journal);
            wasNull = !JournalHelper.CheckIDFromStorage (expectedID, TravelerJournalRepo.Link.FilePath);
            CleanUp ();

            //  Assert
            Assert.True (didDelete && wasNull, $"{AssertHelper.ValidatorMessage ("Did Delete:", didDelete, didDelete, true)} <|> {AssertHelper.ValidatorMessage ("Was Null:", wasNull, wasNull, true)}");
        }

        [Fact]
        public void CanGetEnumerator ()
        {
            //  Arrange
            Initiate ();
            int expectedEntries = 3;
            bool notNull;
            bool notEmpty;
            bool correctAmount;
            JournalHelper.ManualStorageInsertion (JournalFactory.Create (JournalType.TravelerJournal), JournalType.TravelerJournal, TravelerJournalRepo.Link.StoragePath);
            JournalHelper.ManualStorageInsertion (JournalFactory.Create (JournalType.TravelerJournal), JournalType.TravelerJournal, TravelerJournalRepo.Link.StoragePath, true);
            JournalHelper.ManualStorageInsertion (JournalFactory.Create (JournalType.TravelerJournal), JournalType.TravelerJournal, TravelerJournalRepo.Link.StoragePath, true);

            //  Act
            List<ITravelerJournal> pJournal = TravelerJournalRepo.Link.GetEnumerable ().ToList ();
            notNull = journal != null;
            notEmpty = pJournal?.Count != 0;
            correctAmount = pJournal?.Count == 3;
            CleanUp ();

            //  Assert
            Assert.True (notNull && notEmpty && correctAmount, $" {AssertHelper.ValidatorMessage ("Is Null:", !notNull, !notNull, false)} <|> {AssertHelper.ValidatorMessage ("Is Empty:", !notEmpty, ( ( journal != null ) ? ( pJournal.Count.ToString () ) : ( "NaN" ) ), "> 0")} <|> {AssertHelper.ValidatorMessage ("Correct Amount:", correctAmount, ( ( pJournal != null ) ? ( pJournal.Count.ToString () ) : ( "NaN" ) ), expectedEntries)}");
        }

        private void Initiate ()
        {
            if ( !Directory.Exists (TravelerJournalRepo.Link.StoragePath) )
            {
                Directory.CreateDirectory (TravelerJournalRepo.Link.StoragePath);
            }

            patient = PatientHelper.GetNewPatient ();
            journal = JournalFactory.CreateWithPatient (JournalType.TravelerJournal, patient) as ITravelerJournal;
            currentIDIndex++;
        }

        private void CleanUp ()
        {
            if ( Directory.Exists (TravelerJournalRepo.Link.StoragePath.Replace ("\\Journals", string.Empty)) )
            {
                Directory.Delete (TravelerJournalRepo.Link.StoragePath.Replace ("\\Journals", string.Empty), true);
            }
        }
    }
}
