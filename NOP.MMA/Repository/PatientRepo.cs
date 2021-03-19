using NOP.Common.Files;
using NOP.Common.Repository;
using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace NOP.MMA.Repository
{
    /// <summary>
    /// Represents a simple repository system that can store and retrieve <see cref="IPatient"/> <see langword="objects"/>
    /// </summary>
    public class PatientRepo : IRepository<IPatient, string>
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="PatientRepo"/> with its <see langword="default"/> values
        /// </summary>
        private PatientRepo ()
        {
            Storage = new FileHandler (StoragePath);
        }

        /// <summary>
        /// The fully qualified path to the folder, where the storage file is located
        /// </summary>
        protected virtual string StoragePath
        {
            get
            {
                return $"{Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location)}\\Storage\\Patients.csv";
            }
        }
        /// <summary>
        /// The handler that allows for manipulation of the storage file
        /// </summary>
        protected FileHandler Storage { get; }

        private static PatientRepo link = null;
        public static PatientRepo Link
        {
            get
            {
                if ( link == null )
                {
                    link = new PatientRepo ();
                }

                return link;
            }
        }

        public bool DeleteData<IDType> ( IRepositoryEntity<IDType, string> _entity )
        {
            if ( GetDataByIdentifier (_entity.ID) != null )
            {
                string line = Storage.FindLine ($"PatientID{_entity.ID}");
                int lnumber = Storage.GetLineNumber (line);
                Storage.DeleteLine (lnumber);

                return GetDataByIdentifier (_entity.ID) == null;
            }

            return false;
        }

        public IPatient GetDataByIdentifier<IDType> ( IDType _id )
        {
            string data = Storage.FindLine ($"PatientID{_id}");

            IPatient patient = PatientFactory.CreateEmpty ();
            patient.BuildEntity (data);

            return patient;
        }

        public IEnumerable<IPatient> GetEnumerable ()
        {
            List<IPatient> patients = new List<IPatient> ();
            foreach ( string dataStream in Storage.ReadLines () )   //  Read all lines in storage file, and build a patient from it
            {
                IPatient patient = PatientFactory.CreateEmpty ();
                patient.BuildEntity (dataStream);
                patients.Add (patient);
            }

            return patients;
        }

        public bool InsertData<IDType> ( IRepositoryEntity<IDType, string> _data )
        {
            if ( GetDataByIdentifier (_data.ID) == null )
            {
                Storage.WriteLine (_data.SaveEntity ());

                return GetDataByIdentifier (_data.ID) != null;
            }

            return false;
        }

        public bool UpdateData<IDType> ( IRepositoryEntity<IDType, string> _data )
        {
            if ( GetDataByIdentifier (_data.ID) != null )
            {
                string line = Storage.FindLine ($"PatientID{_data.ID}");
                int lNumber = Storage.GetLineNumber (line);
                Storage.InsertLine (_data.SaveEntity (), lNumber);

                return GetDataByIdentifier (_data.ID) != null;
            }

            return false;
        }
    }
}
