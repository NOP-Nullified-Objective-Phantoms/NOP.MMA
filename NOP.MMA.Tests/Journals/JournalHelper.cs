using NOP.Common.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    internal static class JournalHelper
    {
        public static void ManualStorageInsertion ( IJournal _journal, string _path, bool _append = false )
        {
            FileHandler file = new FileHandler ($"{_path}\\P{_journal.ID}.csv");
            file.WriteLine (_journal.SaveEntity (), _append);
        }

        public static bool CheckIDFromStorage ( int _expectedID, string _path )
        {
            FileHandler file = new FileHandler ($"{_path}");
            if ( int.TryParse (file.FindLine ($"JournalID{_expectedID}")?.Split (",")[ 0 ]?.Replace ("JournalID", string.Empty), out int _id) )
            {
                return ( _id == _expectedID );
            }

            return false;
        }

        public static bool CheckValueFromStorage ( string _expectedValue, string _path )
        {
            FileHandler file = new FileHandler (_path);
            return file.FindLine (_expectedValue) != null;
        }
    }
}
