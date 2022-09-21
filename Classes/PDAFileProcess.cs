using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDRSM.Data;
using HDRSM.Classes;
using System.IO;
using System.Windows.Forms;

namespace HDRSM.Classes
{
    internal class PDAFileProcess
    {

        static List<string> inPdaFile = new List<string>();
        static List<string> outPdaFile = new List<string>();

        static string pathInArciv = $"pda_file_archiv/raktarba_be/{DateTime.Now.ToString("yyyyMMdd_HHmm")}/";
        static string pathOutArchiv = $"pda_file_archiv/raktarbol_ki/{DateTime.Now.ToString("yyyyMMdd_HHmm")}/";

        static internal void InFileProcess()
        {
            string[] filenames = Directory.GetFiles("raktarba_be");
            if (filenames.Count() != 0)
            {
                for (int i = 0; i < filenames.Length; i++)
                {
                    foreach (string item in File.ReadAllLines(filenames[i], Encoding.UTF8))
                    {

                        if (!string.IsNullOrEmpty(item))
                        {
                            inPdaFile.Add(item.Trim().Replace('h', 'H'));
                        }
                    }

                    Directory.CreateDirectory(pathInArciv);
                    File.Copy(filenames[i], pathInArciv + filenames[i].Split('\\').Last());
                    File.Delete(filenames[i]);

                }
            }
        }
        static internal void InFileToList()
        {
            try
            {
                for (int j = 0; j < inPdaFile.Count; j++)
                {
                    Data.Data.beviteliLista.Add(new Product(inPdaFile.ElementAt(j), ushort.Parse(inPdaFile.ElementAt(j + 1))));
                    j++;
                }
                inPdaFile.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Helytelen formátumú fájl került a 'raktarba_be' mappába\nKérem ellenőrizze a 'pda_file_archiv' mappában a fájl helyességét");
            }
            catch (Exception)
            {

                throw;
            }

        }
        static internal void FileCheckBeforToStorage()
        {
            List<Product> badItem = new List<Product>();
            List<Product> transferList = new List<Product>();
            if (Data.Data.storage.Count != 0)
            {
                for (int i = 0; i < Data.Data.storage.Count; i++)
                {
                    for (int j = 0; j < Data.Data.beviteliLista.Count; j++)
                    {
                        if (Data.Data.storage.ElementAt(i).HadrianusID == Data.Data.beviteliLista.ElementAt(j).HadrianusID)
                        {
                           
                            badItem.Add(Data.Data.storage.ElementAt(j));
                            //log a hibás bejegyzésről
                        }
                    }
                }
            }
            foreach (Product item in Data.Data.beviteliLista)
            {
                transferList.Add(item);
            }
            var tempor1 = transferList.Except(badItem);

            Data.Data.beviteliLista.Clear();
            foreach (Product item in tempor1)
            {
                Data.Data.beviteliLista.Add(item);
            }

            //?felesleg.
            foreach (Product item in Data.Data.beviteliLista)
            {
                Data.Data.storage.Add(item);
            }

          
        }

        static internal void OutFileProcess()
        {
            string[] filenames2 = Directory.GetFiles("raktarbol_ki");
            if (filenames2.Count() != 0)
            {
                for (int i = 0; i < filenames2.Length; i++)
                {
                    foreach (string item in File.ReadAllLines(filenames2[i], Encoding.UTF8))
                    {

                        if (!string.IsNullOrEmpty(item))
                        {
                            outPdaFile.Add(item.Trim().Replace('h', 'H'));
                        }
                    }
                    Directory.CreateDirectory(pathOutArchiv);
                    File.Copy(filenames2[i], pathOutArchiv + filenames2[i].Split('\\').Last());
                    File.Delete(filenames2[i]);
                }
            }
        }
        static internal void OutFileToList()
        {
            try
            {
                for (int i = 0; i < outPdaFile.Count; i++)
                {
                    Data.Data.kiveteliLista.Add(new Product(outPdaFile.ElementAt(i + 1), ushort.Parse(outPdaFile.ElementAt(i))));
                    i++;
                }
                outPdaFile.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Helytelen formátumú fájl került a 'raktarbol_ki' mappába\nKérem ellenőrizze a 'pda_file_archiv' mappában a fájl helyességét");
            }
            catch (Exception)
            {
                throw;
            }

        }
        static internal void FileChechBeforOutFromStorage()
        {
            List<Product> itemOfErase = new List<Product>();
            List<Product> transferList = new List<Product>();

            for (int i = 0; i < Data.Data.storage.Count; i++)
            {
                for (int j = 0; j < Data.Data.kiveteliLista.Count; j++)
                {
                    if (Data.Data.storage.ElementAt(i).HadrianusID == Data.Data.kiveteliLista.ElementAt(j).HadrianusID && Data.Data.storage.ElementAt(i).StoragePlace == Data.Data.kiveteliLista.ElementAt(j).StoragePlace)
                    {
                        itemOfErase.Add(Data.Data.storage.ElementAt(i));

                    }
                    // ELSE IF ha a hardi stimmel a palc nem akkor log
                }
            }

          
            foreach (Product item in Data.Data.storage)
            {
                transferList.Add(item);
            }
            var tempor1 = transferList.Except(itemOfErase);
            Data.Data.storage.Clear();

            foreach (Product item in tempor1)
            {
                Data.Data.storage.Add(item);
            }
        }



    }
}
