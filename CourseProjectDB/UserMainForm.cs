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
            label21.Text= row["first_name"].ToString();
            label23.Text = row["patronymic"].ToString();
            label24.Text = row["birthday"].ToString();
            label25.Text = row["login"].ToString();
            label26.Text = row["money"].ToString();
            label27.Text = row["status_id"].ToString();

            panel1.BringToFront();
            panel2.SendToBack();
            //panel3.SendToBack();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carriages_systemDataSet.report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.carriages_systemDataSet.report);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.task' table. You can move, or remove it, as needed.
            this.taskTableAdapter.Fill(this.carriages_systemDataSet.task);

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Hide();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void мояИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("Select * from car");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            panel1.BringToFront();
            panel2.SendToBack();
            panel3.SendToBack();
            //dataGridView1.DataSource = dataTable;
        }

        private void свободныеЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.BringToFront();
            panel3.SendToBack();
        }

        private void текущаяЗадачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.BringToFront();
            panel3.SendToBack();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void всеОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel3.BringToFront();
            panel2.SendToBack();
        }

        private void добавитьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel3.BringToFront();
            panel2.SendToBack();
        }

        private void reportBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.reportBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.taskBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.taskBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
        }

        private void taskBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void taskBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.reportBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
        }
    }
}
