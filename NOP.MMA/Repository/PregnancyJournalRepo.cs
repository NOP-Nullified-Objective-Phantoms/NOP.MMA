using NOP.Common.Files;
using NOP.Common.Repository;
using NOP.MMA.Core.Journals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NOP.MMA.Repository
{
    public class PregnancyJournalRepo : JournalRepo, IRepository<IPregnancyJournal, string>
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="PregnancyJournalRepo"/> with its <see langword="default"/> values
        /// </summary>
        protected PregnancyJournalRepo ()
        {
            FileID = "P";
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

        public IEnumerable<IPregnancyJournal> GetEnumerable ()
        {
            List<IPregnancyJournal> pJournals = new List<IPregnancyJournal> ();

            foreach ( FileInfo journalFile in JournalDirectory.GetFiles () )
            {
                if ( journalFile.Name.Contains (FileID) )
                {
                    SetStorage (journalFile.Name);

                    IPregnancyJournal journal = JournalFactory.CreateEmpty (JournalType.PregnancyJournal) as IPregnancyJournal;
                    journal.BuildEntity (Storage.ReadAll ());

                    pJournals.Add (journal);
                }
            }

            return pJournals;
        }

        public IPregnancyJournal GetDataByIdentifier<IDType> ( IDType _id )
        {
            SetStorage ($"{FileID}{_id}");

            IJournal journal = JournalFactory.CreateEmpty (JournalType.PregnancyJournal);
            journal.BuildEntity (Storage.ReadAll ());

            return journal as IPregnancyJournal;
        }

        public bool InsertData<IDType> ( IRepositoryEntity<IDType, string> _data )
        {
            SetStorage ($"{FileID}{_data.ID}");
            Storage.WriteLine (_data.SaveEntity ());

            string filePath = Storage.FilePath;

            return File.Exists (filePath);
        }

        public bool DeleteData<IDType> ( IRepositoryEntity<IDType, string> _entity )
        {
            if ( GetDataByIdentifier (_entity.ID) != null )
            {
                FileInfo file = JournalDirectory.GetFiles ().ToList ().Find (item => item.Name == $"{FileID}{_entity.ID}");
                file.Delete ();

                return file.Exists;
            }

            return false;
        }

        public bool UpdateData<IDType> ( IRepositoryEntity<IDType, string> _data )
        {
            if ( GetDataByIdentifier (_data.ID) != null )
            {
                SetStorage ($"{FileID}{_data.ID}");

                Storage.WriteLine (_data.SaveEntity ());

                return true;
            }

            return false;
        }
    }
}
