using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDRSM.Classes
{
    internal static class DirectoryManagement
    {

        static internal void DirectoryStructureCheck()
        {
            if (!Directory.Exists("database"))
            {
                Directory.CreateDirectory("database");
            }
            if (!Directory.Exists("database/database_backup"))
            {
                Directory.CreateDirectory("database/database_backup");
            }
            if (!Directory.Exists("database/keszlet_backup"))
            {
                Directory.CreateDirectory("database/keszlet_backup");
            }
            if (!Directory.Exists("pda_file_archiv"))
            {
                Directory.CreateDirectory("pda_file_archiv");
            }
            if (!Directory.Exists("pda_file_archiv/raktarbol_ki"))
            {
                Directory.CreateDirectory("pda_file_archiv/raktarbol_ki");
            }
            if (!Directory.Exists("pda_file_archiv/raktarba_be"))
            {
                Directory.CreateDirectory("pda_file_archiv/raktarba_be");
            }
            if (!Directory.Exists("raktarba_be"))
            {
                Directory.CreateDirectory("raktarba_be");
            }
            if (!Directory.Exists("raktarbol_ki"))
            {
                Directory.CreateDirectory("raktarbol_ki");
            }
            if (!Directory.Exists("keszlet_file"))
            {
                Directory.CreateDirectory("keszlet_file");
            }
            if (!Directory.Exists("eladhato_notek"))
            {
                Directory.CreateDirectory("eladhato_notek");
            }

        }



        #region Backup Section
        /// <summary>
        /// Original File location
        /// </summary>
        static public string dataFileLocation = "database/datafile.csv";
        static public string keszletFileLocation = "database/keszlet.csv";
        //

        /// <summary>
        /// Database file backup directory and file name.
        /// </summary>
        static public string backupDirectoryPath = $"database/database_backup/{DateTime.Now.ToString("yyyyMMdd_HHmmss")}/";
        static public string backupFilePath = $"database/database_backup/{DateTime.Now.ToString("yyyyMMdd_HHmmss")}/datafile.csv";
        //


        /// <summary>
        /// Backupfile to new backup folder
        /// </summary>
        /// <param name="createDirectoryPath">create new folder for the copy (route)</param>
        /// <param name="FilePath">exact path of the file</param>
        /// <param name="backupFilePath">backup route to copy folder</param>
        public static void createBackup(string createDirectoryPath, string FilePath, string backupFilePath)
        {
            Directory.CreateDirectory(createDirectoryPath);
            File.Copy(FilePath, backupFilePath);
        }

        #endregion
    }
}
