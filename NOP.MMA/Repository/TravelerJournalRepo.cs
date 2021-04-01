using NOP.Common.Repository;
using NOP.MMA.Core.Journals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NOP.MMA.Repository
{
    public class TravelerJournalRepo : JournalRepo<ITravelerJournal>
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="TravelerJournalRepo"/> with its <see langword="default"/> values
        /// </summary>
        protected TravelerJournalRepo ()
        {
            FileID = "T";
        }

        private static TravelerJournalRepo link = null;
        public static TravelerJournalRepo Link
        {
            get
            {
                if ( link == null )
                {
                    link = new TravelerJournalRepo ();
                }

                return link;
            }
        }

        public override IEnumerable<ITravelerJournal> GetEnumerable ()
        {
            List<ITravelerJournal> tJournals = new List<ITravelerJournal> ();

            foreach ( FileInfo journalFile in JournalDirectory.GetFiles () )
            {
                if ( journalFile.Name.Contains (FileID) )
                {
                    SetStorage (journalFile.Name);

                    ITravelerJournal journal = JournalFactory.CreateEmpty (JournalType.TravelerJournal) as ITravelerJournal;
                    journal.BuildEntity (Storage.ReadAll ());

                    tJournals.Add (journal);
                }
            }

            return tJournals;
        }

        public override ITravelerJournal GetDataByIdentifier<IDType> ( IDType _id )
        {
            SetStorage ($"{FileID}{_id}");

            IJournal journal = JournalFactory.CreateEmpty (JournalType.TravelerJournal);
            journal.BuildEntity (Storage.ReadAll ());

            return journal as ITravelerJournal;
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
                FileInfo file = JournalDirectory.GetFiles ().ToList ().Find (item => item.Name == $"{FileID}{_entity.ID}");
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

                Storage.WriteLine (_data.SaveEntity ());

                return true;
            }

            return false;
        }
    }
}
