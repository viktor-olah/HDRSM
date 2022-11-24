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
    public partial class NewItem : Form
    {
        static bool duplicationCheck = false;
        public NewItem()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            label3.Visible = false;
            label4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox2.Text.Length < 11 && textBox2.Text.Length >= 10 && CSV.duplicateCheck(textBox2.Text.Replace('h', 'H').Trim()) == false)
                { 
                    CSV.Add(new Product(textBox2.Text.Replace('h', 'H'), ushort.Parse(textBox1.Text.Trim())));
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Hibás formátumú vagy létező azonosító / raktárhely számozás!");
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Hibás formátumú azonosító vagy raktárhely számozás!");
                textBox1.Text = "";
                textBox2.Text = "";
                label3.Visible = true;
                label4.Visible = true;
                // throw;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
       
    }
}
