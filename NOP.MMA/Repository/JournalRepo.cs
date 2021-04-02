using NOP.Common.Files;
using NOP.Common.Repository;
using NOP.MMA.Core;
using NOP.MMA.Core.Journals;
using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NOP.MMA.Repository
{
    public abstract class JournalRepo<T> : IRepository<T, string>
    {
        /// <summary>
        /// Initialize a <see cref="JournalRepo"/> <see langword="base"/>
        /// </summary>
        public JournalRepo ()
        {
            if ( !Directory.Exists (StoragePath) )
            {
                try
                {
                    JournalDirectory = Directory.CreateDirectory (StoragePath);
                }
                catch ( System.Exception _e )
                {
                    Debug.LogError (_e);
                    throw;
                }

            }
            else
            {
                JournalDirectory = new DirectoryInfo (StoragePath);
            }
        }

        protected string FileID { get; set; }
        /// <summary>
        /// The fully qualified path to the folder, where the storage file is located
        /// </summary>
        public virtual string StoragePath
        {
            get
            {
                return $"{Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location)}\\Storage\\Journals";
            }
        }
        /// <summary>
        /// The fully qualified path to the current storage file
        /// </summary>
        public virtual string FilePath
        {
            get
            {
                return Storage.FilePath;
            }
        }
        /// <summary>
        /// The handler that allows for manipulation of a <see cref="IJournal"/> storage file
        /// </summary>
        protected FileHandler Storage { get; private set; }
        protected DirectoryInfo JournalDirectory { get; private set; }

        /// <summary>
        /// Change the target of <see cref="Storage"/> based on the provided <paramref name="_id"/>
        /// </summary>
        /// <param name="_id">The ID of the target to locate in storage</param>
        protected void SetStorage ( string _id )
        {
            try
            {
                Storage = new FileHandler ($"{StoragePath}\\{_id}.csv");
            }
            catch ( System.Exception _e )
            {
                Debug.LogError (_e);
                throw;
            }

        }

        /// <summary>
        /// Updates the <see cref="IPatient"/> with the given <paramref name="_patient"/>
        /// </summary>
        /// <param name="_patient"></param>
        /// <returns><see langword="True"/> if the <see cref="IPatient"/> could be updated; otherwise, if not, <see langword="false"/></returns>
        protected bool UpdatePatientData ( IPatient _patient )
        {
            IPatient patient = null;

            try
            {
                patient = PatientRepo.Link.GetDataByIdentifier (_patient.ID);
            }
            catch ( Exception _e )
            {
                Debug.LogWarning (_e.ToString ());
            }

            if ( patient != null )
            {
                return PatientRepo.Link.UpdateData (_patient);
            }
            else
            {
                try
                {
                    throw new Exception ("Couldn't Update Patient!");
                }
                catch ( Exception _e )
                {
                    Debug.LogWarning (_e.ToString ());
                }
            }

            return false;
        }

        public abstract bool DeleteData<IDType> ( IRepositoryEntity<IDType, string> _entity );

        public abstract T GetDataByIdentifier<IDType> ( IDType _id );

        public abstract IEnumerable<T> GetEnumerable ();

        public abstract bool InsertData<IDType> ( IRepositoryEntity<IDType, string> _data );

        public abstract bool UpdateData<IDType> ( IRepositoryEntity<IDType, string> _data );
    }
}
