using HDRSM.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDRSM.Forms
{
    public partial class PlaceChange : Form
    {
        Product oneProduct;
     
       

        public PlaceChange()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            label3.Visible = false;
            label3.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            /*
            foreach (Product item in Data.Data.storage)
            {
               
                if (textBox1.Text.Replace('h','H').Trim() == item.HadrianusID)
                {
                    label3.Visible = true;
                    button1.Enabled = true;
                    label3.ForeColor = Color.Black;
                    label3.Text = item.StoragePlace.ToString() + " a jelenlegi pozíciója" ;
                    oneProduct = item;
                }
            }
            */

            if (!string.IsNullOrEmpty(CSV.LFProdIDPlace(textBox1.Text.Replace('h', 'H').Trim())))
            {

                label3.Visible = true;
                button1.Enabled = true;
                label3.ForeColor = Color.Black;
                label3.Text = CSV.LFProdIDPlace(textBox1.Text.Replace('h', 'H').Trim()) + " a jelenlegi pozíciója";
                

            }

            if (string.IsNullOrEmpty(label3.Text))
            {
                label3.Visible = true;
                label3.ForeColor = Color.Red;
                label3.Text = "Helytelen azonosító!";
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="" && textBox2.Text !="" )
            {

                CSV.PlaceReplace(new Product(textBox1.Text.Replace('h', 'H').Trim(),ushort.Parse(CSV.LFProdIDPlace(textBox1.Text.Replace('h', 'H').Trim()))), new Product(textBox1.Text.Replace('h', 'H').Trim(), ushort.Parse(textBox2.Text)));
                //oneProduct.StoragePlace = ushort.Parse(textBox2.Text);
                DialogResult = DialogResult.OK;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
