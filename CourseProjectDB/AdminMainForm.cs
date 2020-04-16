using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectDB
{
    public partial class AdminMainForm : Form
    {
        Main main = null;
        DataTable dataTable = null;

        public AdminMainForm(Main main, DataTable dataTable)
        {
            InitializeComponent();
            this.main = main;
            this.dataTable = dataTable;
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Hide();
        }
    }
}
