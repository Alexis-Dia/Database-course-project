using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectDB
{
    public partial class UserForm : Form
    {

        Main main = null;

        public UserForm(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Hide();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void свободныеЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void мояИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("Select * from car");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }
    }
}
