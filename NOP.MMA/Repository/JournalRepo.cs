using NOP.Common.Files;
using NOP.MMA.Core.Journals;
using System.IO;
using System.Reflection;

namespace NOP.MMA.Repository
{
    public abstract class JournalRepo
    {
        /// <summary>
        /// Initialize a <see cref="JournalRepo"/> <see langword="base"/>
        /// </summary>
        public JournalRepo ()
        {
            if ( !Directory.Exists (StoragePath) )
            {
                JournalDirectory = Directory.CreateDirectory (StoragePath);
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
        protected virtual string StoragePath
        {
            get
            {
                return $"{Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location)}\\Storage\\Journals";
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
            Storage = new FileHandler ($"{StoragePath}\\{_id}.csv");
        }
    }
}
