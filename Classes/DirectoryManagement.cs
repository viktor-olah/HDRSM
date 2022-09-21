using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDRSM.Classes
{
    internal class DirectoryManagement
    {
        static internal void DirectoryStructureCheck()
        {
            if (!Directory.Exists("database"))
            {
                Directory.CreateDirectory("database");
            }
            if (!Directory.Exists("database/backup"))
            {
                Directory.CreateDirectory("database/backup");
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
        }
    }
}
