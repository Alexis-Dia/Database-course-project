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
    public partial class UserMainForm : Form
    {

        Main main = null;
        DataTable dataTable = null;

        public UserMainForm(Main main, DataTable dataTable)
        {
            InitializeComponent();
            this.main = main;
            this.dataTable = dataTable;

            DataRow row = dataTable.Rows[0];
            textBox11.Text = row["first_name"].ToString();
            textBox12.Text = row["last_name"].ToString();
            textBox13.Text = row["patronymic"].ToString();
            textBox14.Text = row["birthday"].ToString();
            textBox15.Text = row["login"].ToString();
            textBox16.Text = row["money"].ToString();
            textBox17.Text = row["status_id"].ToString();

            panel1.BringToFront();
            panel2.SendToBack();
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

            //Example for getting tasks using stored procedures:

            /*DataTable dt = new DataTable();
            SqlConnection myConn = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=True;User ID=root;Password=root;");
            myConn.Open();
            SqlCommand myCmd = new SqlCommand("GetMineFinishedTasks", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;
            SqlParameter lobjSqlParam = new SqlParameter("@driver_id", 2);
            myCmd.Parameters.Add(lobjSqlParam);
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/

            //Example for getting tasks using users functions:
/*            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("SELECT * from GetMineFinishedTasks(2)");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;*/

            panel1.SendToBack();
            panel2.BringToFront();
        }

        private void мояИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("Select * from car");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            panel1.BringToFront();
            panel2.SendToBack();
            //dataGridView1.DataSource = dataTable;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void текущаяЗадачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.BringToFront();
        }

        private void всеОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.BringToFront();
        }

        private void добавитьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.BringToFront();
        }
    }
}
