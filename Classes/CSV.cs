using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDRSM.Data;

namespace HDRSM.Classes
{
    internal static class CSV
    {
        static CSV() 
        {
            
            if (!File.Exists(DirectoryManagement.dataFileLocation))
            {
                throw new Exception("Adat fájl nem található! Hiba a kapcsolódás során");
            }
            
            
        }


        private static void datafileREAD()
        {
            foreach (string item in File.ReadAllLines(DirectoryManagement.dataFileLocation, Encoding.UTF8))
            {
                string[] oneline = item.Split(';');
                Data.Data.temp.Add(new Product(oneline[0], ushort.Parse(oneline[1])));
            }

            File.Delete(DirectoryManagement.dataFileLocation);

        }
        private static void datafileWRITE()
        {
            FileStream csvFile = new FileStream(DirectoryManagement.dataFileLocation, FileMode.Create, FileAccess.Write);
            StreamWriter dataWrite = new StreamWriter(csvFile);
            foreach (Product item in Data.Data.temp)
            {
                dataWrite.WriteLine(item.CSVFormat());
            }
            dataWrite.Close();
            csvFile.Close();
        }




        // new data
        public static void Add(Product element)
        {
            datafileREAD();
            bool duplicateItem = false;
            // duplicate test
            foreach (Product item in Data.Data.temp)
            {
                if (item.HadrianusID == element.HadrianusID && item.StoragePlace == element.StoragePlace)
                {
                    duplicateItem = true;
                }
            }
            if (duplicateItem == false)
            {
                Data.Data.temp.Add(element);
            }
            datafileWRITE();
            Data.Data.temp.Clear();
        }
        //replace
        public static void PlaceReplace(Product delete, Product add)
        {
            Delete(delete);
            Add(add);
        }

        //delete
        public static void Delete(Product element)
        {
            datafileREAD();
            
            int indexOfErase = -1;
            for (int i = 0; i < Data.Data.temp.Count; i++)
            {
                if (Data.Data.temp.ElementAt(i).HadrianusID == element.HadrianusID && Data.Data.temp.ElementAt(i).StoragePlace == element.StoragePlace)
                {
                    indexOfErase = i;
                }
            }
            Data.Data.temp.RemoveAt(indexOfErase);
            
            datafileWRITE();
            Data.Data.temp.Clear();
        }

        //duplicate check
        public static bool duplicateCheck(string tbText)
        {

            bool validation = false;
            foreach (string item in File.ReadAllLines(DirectoryManagement.dataFileLocation, Encoding.UTF8))
            {
                string[] oneline = item.Split(';');
                if (oneline[0] == tbText)
                {
                    validation = true;
                }
            }


            return validation;
        }

        //Prod ID place
        public static string LFProdIDPlace(string tbText)
        {
            bool validation = false;
            string placeTemp = "";
            foreach (string item in File.ReadAllLines(DirectoryManagement.dataFileLocation, Encoding.UTF8))
            {
                string[] oneline = item.Split(';');
                if (oneline[0] == tbText)
                {
                    validation = true;
                    placeTemp= oneline[1];
                }
            }

            return placeTemp;

        }


    }
}
