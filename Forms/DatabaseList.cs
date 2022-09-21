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
    public partial class DatabaseList : Form
    {
        public DatabaseList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            foreach (Product item in Data.Data.storage)
            {
                listBox1.Items.Add(item);
            }
            label2.Text = $"Összesen: {Data.Data.storage.Count} DB";
        }
    }
}
