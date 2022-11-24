using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDRSM.Classes;
using HDRSM.Data;
using System.Reflection;
using System.Threading;
using System.Windows.Input;
//using System.Drawing;
using HDRSM.Forms;
using System.Reflection.Emit;
using System.Drawing.Drawing2D;


namespace HDRSM
{
    public partial class Form1 : Form
    {
        static string tb1ItemTemp;

        public Form1()
        {
            InitializeComponent();
            ScreenSetup();
            timer1.Enabled = true;
            this.Text = Data.Data.version;
            
            csvstop.Visible = true;
            mssqlstop.Visible = true;

            greencsv.Visible = false;
            greenmssql.Visible = false;
            
         
         
            label2.Visible = false;
            label3.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

         

     


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryManagement.DirectoryStructureCheck();
            Keszlet.Keszlet_Read();

            try
            {
                //First storage_data load to memory
                //Product.dataFromCSV();
                greencsv.Visible = true;
                csvstop.Visible = false;
            } 
            catch (Exception)
            {
                greencsv.Visible = false;
                csvstop.Visible = true;
                MessageBox.Show("Betöltés nem lehetséges CSV fájlból. Hibás vagy nem létezik");
            }
            

            #region In_Storage_Process
            PDAFileProcess.InFileProcess();
            PDAFileProcess.InFileToList();
            PDAFileProcess.FileCheckBeforToStorage();
            #endregion

            #region Outfrom_Storage_Process
            PDAFileProcess.OutFileProcess();
            PDAFileProcess.OutFileToList();
            PDAFileProcess.FileChechBeforOutFromStorage();
            #endregion
           
        }

   

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Product.dataToCSV(Data.Data.storage);
           // Keszlet.Keszlet_archive(Data.Data.notebooks);
        }

        #region Screen
        private void ScreenSetup()
        {
            ScreenControl();
            DynamicWorkingArea();

        }
        private void ScreenControl()
        {
            if (Screen.PrimaryScreen.WorkingArea.Width < 1360 || Screen.PrimaryScreen.WorkingArea.Height < 720)
            {
                MessageBox.Show("Not supported Screen Resolution!", "Resolution Error", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private void DynamicWorkingArea()
        {
            if ((Screen.PrimaryScreen.WorkingArea.Width > 1000 && Screen.PrimaryScreen.WorkingArea.Height > 600)&& (Screen.PrimaryScreen.WorkingArea.Width < 1900 && Screen.PrimaryScreen.WorkingArea.Height < 1000))
            {
                this.Width = Screen.PrimaryScreen.WorkingArea.Width - 10;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height - 10;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.Width = Screen.PrimaryScreen.WorkingArea.Width - 500;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height - 250;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            IDControll(textBox1.Text.Replace('h','H'));
        }

        private void IDControll(string hadrianusID)
        {
            if (!string.IsNullOrEmpty(CSV.LFProdIDPlace(hadrianusID)))
            {
                label2.Visible = true;
                label2.Text = $"A {hadrianusID} azonosító a {CSV.LFProdIDPlace(hadrianusID)}. rakhelyen található meg!";
               
                outOfStorageOption(hadrianusID);
                tb1ItemTemp = hadrianusID;

            }
            else
            {
                label2.Visible = true;
                label2.Text = $"A {hadrianusID} azonosító nem található a raktár rendszerben!";
            }
            ;
            /*
            bool noItem = false;
            if (!string.IsNullOrEmpty(hadrianusID)) {
                foreach (Product item in Data.Data.storage)
                {
                    if (item.HadrianusID == hadrianusID)
                    {
                        label2.Visible = true;
                        label2.Text = $"A {hadrianusID} azonosító a {item.StoragePlace}. rakhelyen található meg!";
                        noItem = true;
                        outOfStorageOption(hadrianusID);
                        tb1ItemTemp = hadrianusID;
                    }
                }
                if (noItem == false)
                {
                    label2.Visible = true;
                    label2.Text = $"A {hadrianusID} azonosító nem található a raktár rendszerben!";
                   
                }
            */
               
               
            
           
        }

        private void outOfStorageOption(string hID)
        {
            label3.Text = $"Kiszeretné-e venni a {hID} azonosítót a rakhelyről? (Rendeléshez)";
            label3.Visible = true;

            button2.Visible = true;
            button3.Visible = true;

            button2.Text = "Igen";
            button3.Text = "Nem";


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                IDControll(textBox1.Text.Replace('h', 'H'));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*
            SolidBrush alszurke = new SolidBrush(Color.Green);
            //Rectangle negyzet = new Rectangle(-5, this.Height - 50, this.Width + 10, 50);
            Rectangle negyzet = new Rectangle(label6.Left + 58, label6.Top + 680, 30, 30);
           
            e.Graphics.FillRectangle(alszurke, negyzet);
          */
          
        }
     
        // yes
        private void button2_Click(object sender, EventArgs e)
        {
            /*
            int indexOfErase = -1;
            for (int i = 0; i < Data.Data.storage.Count; i++)
            {
                if (Data.Data.storage.ElementAt(i).HadrianusID == tb1ItemTemp)
                {
                    indexOfErase = i;
                }
            }
            Data.Data.storage.RemoveAt(indexOfErase);
            */
            CSV.Delete(new Product(textBox1.Text.Replace('h', 'H').Trim(),ushort.Parse(CSV.LFProdIDPlace(textBox1.Text.Replace('h', 'H').Trim()))));

            buttonAndLabelHidden();

            MessageBox.Show($"A {tb1ItemTemp} Törlésre került a rendszerből.");
            tb1ItemTemp = "";

        }

        // no
        private void button3_Click(object sender, EventArgs e)
        {
            buttonAndLabelHidden();
            tb1ItemTemp = "";
        }

        private void buttonAndLabelHidden()
        {
            

            textBox1.Text = "";
            label2.Visible = false;
            label3.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewItem newWindow = new NewItem();
            newWindow.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DatabaseList newWindow = new DatabaseList();
            newWindow.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Interval = 30000;
            label4.Text = DateTime.Today.ToString("yyyy. MM. dd");
            label5.Text = DateTime.Now.ToString("      " + "HH:mm");

            #region In_Storage_Process
            PDAFileProcess.InFileProcess();
            PDAFileProcess.InFileToList();
            PDAFileProcess.FileCheckBeforToStorage();
            #endregion

            #region Outfrom_Storage_Process
            PDAFileProcess.OutFileProcess();
            PDAFileProcess.OutFileToList();
            PDAFileProcess.FileChechBeforOutFromStorage();
            #endregion

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PlaceChange newWindow = new PlaceChange();
            newWindow.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //CSV.proba();

            /*
            StockForm newWindow = new StockForm();
            newWindow.ShowDialog();
            */
        }
    }
}
