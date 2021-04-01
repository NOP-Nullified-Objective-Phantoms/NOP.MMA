using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Defines a value that can be signed and stamped with a date
    /// </summary>
    public struct JournalData
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="JournalData"/>
        /// </summary>
        /// <param name="_date"></param>
        /// <param name="_initials"></param>
        /// <param name="_value"></param>
        public JournalData (DateTime _date, string _initials, string _value )
        {
            Date = _date;
            Initials = _initials;
            Value = _value;
        }

        /// <summary>
        /// The data
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// The date the data was provided
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// The initials of the person, who signed the data entry
        /// </summary>
        public string Initials { get; }
    }
}
