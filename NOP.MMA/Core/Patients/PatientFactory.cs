using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Patients
{
    public static class PatientFactory
    {
        /// <summary>
        /// Creates a new empty <see cref="IPatient"/> <see langword="object"/> that does not increment the ID counter
        /// </summary>
        /// <returns>A new instance of type <see cref="IPatient"/> where the ID is set to zero.</returns>
        public static IPatient CreateEmpty ()
        {
            return new Patient (0);
        }

        /// <summary>
        /// Create a new <see cref="IPatient"/> <see langword="object"/>
        /// </summary>
        /// <returns>A new empty <see cref="IPatient"/> <see langword="object"/> that increments the ID counter</returns>
        public static IPatient Create ()
        {
            return new Patient ();
        }

        /// <summary>
        /// Creates a new <see cref="IPatient"/> <see langword="object"/> based on <see cref="IPatientData"/> and <see cref="IPatientSocialData"/>
        /// </summary>
        /// <param name="_data">The container that represents the patients private data</param>
        /// <param name="_socialData">The container that represents the patiens social data</param>
        /// <returns>A new populated <see cref="IPatient"/> <see langword="object"/> that increments the ID counter</returns>
        public static IPatient Create ( IPatientData _data, IPatientSocialData _socialData )
        {
            return new Patient ()
            {
                Address = _data.Address,
                ChildFathersName = _socialData.ChildFathersName,
                ChildFathersSSN = _socialData.ChildFathersSSN,
                CivilStatus = _socialData.CivilStatus,
                Cohibitable = _socialData.Cohibitable,
                DoctorsAddress = _data.DoctorsAddress,
                DoctorsName = _data.DoctorsName,
                DoctorsPhone = _data.DoctorsPhone,
                Email = _data.Email,
                Name = _data.Name,
                Nationality = _socialData.Nationality,
                NeedTranslator = _socialData.NeedTranslator,
                OtherInfo = _socialData.OtherInfo,
                PrivateGP = _data.PrivateGP,
                PrivatePhone = _data.PrivatePhone,
                SSN = _data.SSN,
                TranslatorLanguage = _socialData.TranslatorLanguage,
                WorkPhone = _data.WorkPhone
            };
        }
    }
}
