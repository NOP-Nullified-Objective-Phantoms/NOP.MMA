using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NOP.MMA.Core.Journals
{
    public class JournalFactoryTests
    {
        private static int currentIDIndex = 1;  //  Keep track of the amount of patients that are created during the tests

        [Fact]
        public void CanCreateEmptyPregnancyJournal ()
        {
            //  Arrange
            int expectedID = 0;
            bool notNull;
            bool correctID;
            IPregnancyJournal pJournal;

            //  Act
            pJournal = JournalFactory.CreateEmpty (JournalType.PregnancyJournal) as IPregnancyJournal;
            notNull = pJournal != null;
            correctID = pJournal.ID == expectedID;

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {( ( notNull ) ? ( pJournal.ID.ToString () ) : ( "NaN" ) )} | Expected: {expectedID}}}");
        }

        [Fact]
        public void CanCreatePregnancyJournalWithID ()
        {
            //  Arrange
            int expectedID = currentIDIndex;
            bool notNull;
            bool correctID;
            IPregnancyJournal pJournal;

            //  Act
            pJournal = JournalFactory.Create (JournalType.PregnancyJournal) as IPregnancyJournal;
            notNull = pJournal != null;
            correctID = pJournal.ID == expectedID;
            currentIDIndex++;   //  Incrementing the ID index in case another journal is created after this test

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {( ( notNull ) ? ( pJournal.ID.ToString () ) : ( "NaN" ) )} | Expected: {expectedID}}}");
        }

        [Fact]
        public void CanCreatePregnancyJournalFromPatient ()
        {
            //  Arrange
            string expectedSSN = "MyChildsFathersSocialSecurityNumber";
            int expectedID = currentIDIndex;
            IPregnancyJournal pJournal;
            IPatient patient = PatientFactory.CreateEmpty ();
            patient.ChildFathersSSN = expectedSSN;
            bool notNull;
            bool correctID;
            bool correctSSN;

            //  Act
            pJournal = JournalFactory.CreateWithPatient (JournalType.PregnancyJournal, patient) as IPregnancyJournal;
            notNull = pJournal != null;
            correctID = pJournal.ID == expectedID;
            correctSSN = pJournal.PatientData.ChildFathersSSN == expectedSSN;
            currentIDIndex++;   //  Incrementing the ID index in case another journal is created after this test

            //  Assert
            Assert.True (( notNull && correctID ), $"Is Null: {!notNull} {{Value: {!notNull} | Expected: {false}}}<|> Correct ID: {correctID} {{Value: {( ( notNull ) ? ( pJournal.ID.ToString () ) : ( "NaN" ) )} | Expected: {expectedID}}} <|> CorrectSSN: {correctSSN} {{Value: {pJournal.PatientData.ChildFathersSSN} | Expected: {expectedSSN}}}");
        }
    }
}
