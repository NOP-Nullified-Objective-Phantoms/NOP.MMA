using NOP.Common.Files;
using NOP.Common.Repository;
using NOP.MMA.Core;
using NOP.MMA.Core.Journals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NOP.MMA.Repository
{
    public class PregnancyJournalRepo : JournalRepo<IPregnancyJournal>
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="PregnancyJournalRepo"/> with its <see langword="default"/> values
        /// </summary>
        protected PregnancyJournalRepo ()
        {
            FileID = "P";

            if ( !Directory.Exists (StoragePath) )
            {
                Directory.CreateDirectory (StoragePath);
            }
        }

        private static PregnancyJournalRepo link = null;
        public static PregnancyJournalRepo Link
        {
            get
            {
                if ( link == null )
                {
                    link = new PregnancyJournalRepo ();
                }

                return link;
            }
        }

        public override IEnumerable<IPregnancyJournal> GetEnumerable ()
        {
            List<IPregnancyJournal> pJournals = new List<IPregnancyJournal> ();

            foreach ( FileInfo journalFile in JournalDirectory.GetFiles () )
            {
                if ( journalFile.Name.Contains (FileID) )
                {
                    SetStorage (journalFile.Name);

                    IPregnancyJournal journal = JournalFactory.CreateEmpty (JournalType.PregnancyJournal) as IPregnancyJournal;
                    try
                    {
                        journal.BuildEntity (Storage.ReadAll ());
                    }
                    catch ( Exception _e )
                    {
                        Debug.LogWarning (_e.ToString ());
                    }

                    pJournals.Add (journal);
                }
            }

            return pJournals;
        }

        public override IPregnancyJournal GetDataByIdentifier<IDType> ( IDType _id )
        {
            SetStorage ($"{FileID}{_id}");

            IJournal journal = JournalFactory.CreateEmpty (JournalType.PregnancyJournal);
            try
            {
                journal.BuildEntity (Storage.ReadAll ());
            }
            catch ( Exception _e )
            {
                Debug.LogWarning (_e.ToString ());
            }

            return journal as IPregnancyJournal;
        }

        public override bool InsertData<IDType> ( IRepositoryEntity<IDType, string> _data )
        {
            SetStorage ($"{FileID}{_data.ID}");
            Storage.WriteLine (_data.SaveEntity ());

            string filePath = Storage.FilePath;

            return File.Exists (filePath);
        }

        public override bool DeleteData<IDType> ( IRepositoryEntity<IDType, string> _entity )
        {
            if ( GetDataByIdentifier (_entity.ID) != null )
            {
                FileInfo file = JournalDirectory.GetFiles ().ToList ().Find (item => item.Name == $"{FileID}{_entity.ID}.csv");
                file.Delete ();

                return file.Exists;
            }

            return false;
        }

        public override bool UpdateData<IDType> ( IRepositoryEntity<IDType, string> _data )
        {
            if ( GetDataByIdentifier (_data.ID) != null )
            {
                SetStorage ($"{FileID}{_data.ID}");

                if ( UpdatePatientData (( ( IPregnancyJournal ) _data ).PatientData) )
                {
                    Storage.WriteLine (_data.SaveEntity ());
                    return true;
                }
            }

            return false;
        }
    }
}
