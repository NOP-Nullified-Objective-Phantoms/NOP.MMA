using NOP.Common.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    /// <summary>
    /// Represents a medical patient with GA and social details
    /// </summary>
    internal class Patient : IPatient, IRepositoryEntity<int, string>
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="Patient"/> with its <see langword="default"/> values
        /// </summary>
        public Patient ()
        {
            ID = PatientCounter;
        }

        private int patientCounter = 0;
        /// <summary>
        /// Increments the patient counter and returns it. (<i><strong>Use this to set the ID of new <see cref="Patient"/> objects</strong></i>)
        /// </summary>
        protected virtual int PatientCounter
        {
            get
            {
                return patientCounter++;
            }
        }

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
        public MaritalStatus CivilStatus { get; set; }
        public bool Cohibitable { get; set; }
        public string ChildFathersName { get; set; }
        public string ChildFathersSSN { get; set; }
        public bool NeedTranslator { get; set; }
        public string TranslatorLanguage { get; set; }
        public string Nationality { get; set; }
        public string OtherInfo { get; set; }
        public int ID { get; private set; }

        public void BuildEntity ( string _data )
        {
            string[] data = _data.Split (",");

            if ( data.Length == 19 && int.TryParse (data[ 0 ].Replace ("PatientID", string.Empty), out int _id) && int.TryParse (data[ 11 ], out int _civilStatus) && bool.TryParse (data[ 12 ], out bool _cohibitable) && bool.TryParse (data[ 15 ], out bool _needTranslator) )
            {
                ID = _id;
                SSN = data[ 1 ];
                Name = data[ 2 ];
                Address = data[ 3 ];
                Email = data[ 4 ];
                PrivatePhone = data[ 5 ];
                WorkPhone = data[ 6 ];
                PrivateGP = data[ 7 ];
                DoctorsName = data[ 8 ];
                DoctorsAddress = data[ 9 ];
                DoctorsPhone = data[ 10 ];
                CivilStatus = ( MaritalStatus ) _civilStatus;
                Cohibitable = _cohibitable;
                ChildFathersName = data[ 13 ];
                ChildFathersSSN = data[ 14 ];
                NeedTranslator = _needTranslator;
                TranslatorLanguage = data[ 16 ];
                Nationality = data[ 17 ];
                OtherInfo = data[ 18 ];
            }
        }

        public string SaveEntity ()
        {
            return $"PatientID{ID},{SSN},{Name},{Address},{Email},{PrivatePhone},{WorkPhone},{PrivateGP},{DoctorsName},{DoctorsAddress},{DoctorsPhone},{( int ) CivilStatus},{Cohibitable.ToString ()},{ChildFathersName},{ChildFathersSSN},{NeedTranslator.ToString ()},{TranslatorLanguage},{Nationality},{OtherInfo}";
        }
    }
}
