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
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();

            foreach (Keszlet item in Data.Data.notebooks)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
