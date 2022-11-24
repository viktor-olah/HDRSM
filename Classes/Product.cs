using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDRSM.Classes;

namespace HDRSM.Classes
{
    internal class Product
    {
        string hadrianusID;
        ushort storagePlace;
        //string category;
     

        public Product(string hadrianusID, ushort storagePlace)
        {
            HadrianusID = hadrianusID;
            StoragePlace = storagePlace;
        }

        public string HadrianusID { get => hadrianusID; set => hadrianusID = value; }
        public ushort StoragePlace { get => storagePlace; set => storagePlace = value; }

        public override string ToString()
        {
            return $"{HadrianusID} - {storagePlace}";
        }

        public string CSVFormat()
        {
            return $"{HadrianusID};{StoragePlace}";
        }
        public static void dataToCSV(List<Product>storageList)
        {
            FileStream csvFile = new FileStream("database/datafile.csv", FileMode.Create,FileAccess.Write);
            StreamWriter dataWrite = new StreamWriter(csvFile);
            foreach  (Product item in storageList)
            {
                dataWrite.WriteLine(item.CSVFormat());
            }
            dataWrite.Close();
            csvFile.Close();

            DirectoryManagement.createBackup(DirectoryManagement.backupDirectoryPath, DirectoryManagement.dataFileLocation,DirectoryManagement.backupFilePath);
        }

       
        public static void dataFromCSV()
        {
            if (File.Exists("database/datafile.csv"))
            {
                foreach (string item in File.ReadAllLines("database/datafile.csv", Encoding.UTF8))
                {
                    string[] oneline = item.Split(';');
                    Data.Data.storage.Add(new Product(oneline[0], ushort.Parse(oneline[1])));
                }
            }
            
            
        }

       
        
    }
}
