using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HDRSM.Classes
{
    internal class Keszlet
    {
        string behozataliDatum;
        string cegnev;
        string darabszam;
        string fuggveny;
        string ismetles;
        string gyariszam;
        string hadrianusAzonosito;
        string gyarto;
        string noteNev;
        string cpuNev;
        string cpuModell;
        string cpuOrajel;
        string ramMerete;
        string ramTipus;
        string hddMerete;
        string hddTipus;
        string hddAllapot;
        string badsector;
        string cdDvd;
        string kijelzoMeret;
        string kijelzoTipusa;
        string kijelzoFelbontas;
        string vgaTipusa;
        string vgaKimenet;
        string webcam;
        string licence;
        string licenceSorszam;
        string billentyuzetNyelve;
        string akku;
        string allapot;
        string muszakiHiba;
        string esztetikaiHiba;
        string csomagolas;
        string javitvaBovitve;
        string beszerzesiAr;
        string aregyhusz;
        string arhuszPlusz;
        string eur;
        string nettoEladasiAr;
        string eladasiDatum;
        string szallito;
        string szamlazoKat;
        string szamlazoLeltar;
        string leltarDatum;
        string raktarhely;
        string egyeb;
        string leiras;
        string nettoKisKerAr;
        string nyereseg;
        string szallitoJavitas;

        public Keszlet(string behozataliDatum, string cegnev, string darabszam, string fuggveny, string ismetles, string gyariszam, string hadrianusAzonosito, string gyarto, string noteNev, string cpuNev, string cpuModell, string cpuOrajel, string ramMerete, string ramTipus, string hddMerete, string hddTipus, string hddAllapot, string badsector, string cdDvd, string kijelzoMeret, string kijelzoTipusa, string kijelzoFelbontas, string vgaTipusa, string vgaKimenet, string webcam, string licence, string licenceSorszam, string billentyuzetNyelve, string akku, string allapot, string muszakiHiba, string esztetikaiHiba, string csomagolas, string javitvaBovitve, string beszerzesiAr, string aregyhusz, string arhuszPlusz, string eur, string nettoEladasiAr, string eladasiDatum, string szallito, string szamlazoKat, string szamlazoLeltar, string leltarDatum, string raktarhely, string egyeb, string leiras, string nettoKisKerAr, string nyereseg, string szallitoJavitas)
        {
            this.behozataliDatum = behozataliDatum;
            this.cegnev = cegnev;
            this.darabszam = darabszam;
            this.fuggveny = fuggveny;
            this.ismetles = ismetles;
            this.gyariszam = gyariszam;
            this.hadrianusAzonosito = hadrianusAzonosito;
            this.gyarto = gyarto;
            this.noteNev = noteNev;
            this.cpuNev = cpuNev;
            this.cpuModell = cpuModell;
            this.cpuOrajel = cpuOrajel;
            this.ramMerete = ramMerete;
            this.ramTipus = ramTipus;
            this.hddMerete = hddMerete;
            this.hddTipus = hddTipus;
            this.hddAllapot = hddAllapot;
            this.badsector = badsector;
            this.cdDvd = cdDvd;
            this.kijelzoMeret = kijelzoMeret;
            this.kijelzoTipusa = kijelzoTipusa;
            this.kijelzoFelbontas = kijelzoFelbontas;
            this.vgaTipusa = vgaTipusa;
            this.vgaKimenet = vgaKimenet;
            this.webcam = webcam;
            this.licence = licence;
            this.licenceSorszam = licenceSorszam;
            this.billentyuzetNyelve = billentyuzetNyelve;
            this.akku = akku;
            this.allapot = allapot;
            this.muszakiHiba = muszakiHiba;
            this.esztetikaiHiba = esztetikaiHiba;
            this.csomagolas = csomagolas;
            this.javitvaBovitve = javitvaBovitve;
            this.beszerzesiAr = beszerzesiAr;
            this.aregyhusz = aregyhusz;
            this.arhuszPlusz = arhuszPlusz;
            this.eur = eur;
            this.nettoEladasiAr = nettoEladasiAr;
            this.eladasiDatum = eladasiDatum;
            this.szallito = szallito;
            this.szamlazoKat = szamlazoKat;
            this.szamlazoLeltar = szamlazoLeltar;
            this.leltarDatum = leltarDatum;
            this.raktarhely = raktarhely;
            this.egyeb = egyeb;
            this.leiras = leiras;
            this.nettoKisKerAr = nettoKisKerAr;
            this.nyereseg = nyereseg;
            this.szallitoJavitas = szallitoJavitas;
        }
        public override string ToString()
        {
            return $"{hadrianusAzonosito} - {gyarto} - {noteNev} - {allapot}";
        }



        internal static void Keszlet_Read()
        {
            if (File.Exists("keszlet_file/2022.csv"))
            {
                foreach (string item in File.ReadAllLines("keszlet_file/2022.csv", Encoding.UTF8).Skip(1))
                {
                    string[] egysor = item.Split(';');

                    Data.Data.notebooks.Add(new Keszlet(egysor[0], egysor[1], egysor[2], egysor[3], egysor[4], egysor[5], egysor[6], egysor[7], egysor[8], egysor[9], egysor[10], egysor[11], egysor[12], egysor[13], egysor[14], egysor[15], egysor[16], egysor[17], egysor[18], egysor[19], egysor[20], egysor[21], egysor[22], egysor[23], egysor[24], egysor[25], egysor[26], egysor[27], egysor[28], egysor[29], egysor[30], egysor[31], egysor[32], egysor[33], egysor[34], egysor[35], egysor[36], egysor[37], egysor[38], egysor[39], egysor[40], egysor[41], egysor[42], egysor[43], egysor[44], egysor[45], egysor[46], egysor[47], egysor[48], egysor[49]));

                }
            }

        }
        /*
       public string CSVFormat()
       {
           return $"";
       }


       public static void Keszlet_archive(List<Keszlet> keszlet)
       {
           FileStream csvFile = new FileStream("database/keszlet_archive/keszlet_file.csv", FileMode.Create, FileAccess.Write);
           StreamWriter dataWrite = new StreamWriter(csvFile);
           foreach (Keszlet item in keszlet)
           {
               dataWrite.WriteLine(item.CSVFormat());
           }
           dataWrite.Close();
           csvFile.Close();

           Keszlet_backup();
       }

       public static void Keszlet_backup()
       {
           string backupDirectoryPath = $"database/keszlet_archive/backup/{DateTime.Now.ToString("yyyyMMdd_HHmmss")}/";
           string backupFilePath = $"database/keszlet_archive/{DateTime.Now.ToString("yyyyMMdd_HHmmss")}/keszlet_file.csv";
           Directory.CreateDirectory(backupDirectoryPath);
           File.Copy("keszlet_file/2022", backupFilePath);
       }
        */


    }
}
