﻿using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Serves as the base for all journal entitites
    /// </summary>
    internal abstract class Journal : IJournal
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="Journal"/> with its <see langword="default"/> values. An ID will be generated if one is not provided
        /// </summary>
        /// <param name="_id">The ID to assign the new <see cref="IJournal"/> <see langword="object"/></param>
        public Journal ( int _id = -1 )
        {
            if ( _id == -1 )
            {
                ID = JournalCounter;
            }
            else if ( _id > 0 )
            {
                ID = _id;
            }
            else
            {
                throw new ArgumentOutOfRangeException ("Invalid ID argument. _id must be higher or equal to 0");
            }
        }

        private static int journalCounter = 0;
        /// <summary>
        /// Increments the journal counter and returns it. (<i><strong>Use this to set the ID of new <see cref="Journal"/> objects</strong></i>)
        /// </summary>
        protected virtual int JournalCounter
        {
            get
            {
                return journalCounter++;
            }
        }

        public IPatient PatientData { get; set; }
        public JournalDest JournalDestination { get; set; }
        public int ID { get; private set; }

        public abstract string SaveEntity ();

        public abstract void BuildEntity ( string _data );
    }
}