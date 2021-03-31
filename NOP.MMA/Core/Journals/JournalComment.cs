using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents a comment for an <see cref="IJournal"/>
    /// </summary>
    public struct JournalComment
    {
        /// <summary>
        /// The date the comment was provided
        /// </summary>
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
