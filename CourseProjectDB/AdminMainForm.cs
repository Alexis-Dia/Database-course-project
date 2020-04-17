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

        private void carBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);

        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carriages_systemDataSet.brand' table. You can move, or remove it, as needed.
            this.brandTableAdapter.Fill(this.carriages_systemDataSet.brand);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.carriages_systemDataSet.report);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.task' table. You can move, or remove it, as needed.
            this.taskTableAdapter.Fill(this.carriages_systemDataSet.task);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.carriages_systemDataSet.user);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.car' table. You can move, or remove it, as needed.
            this.carTableAdapter.Fill(this.carriages_systemDataSet.car);

            panel1.SendToBack();
            panel2.BringToFront();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();

            userDataGridView.Columns[0].Width = 50;

        }

        private void задачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.BringToFront();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.BringToFront();
            panel4.SendToBack();
            panel5.SendToBack();
        }

        private void отчеты1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.BringToFront();
            panel5.SendToBack();
        }

        private void машиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
        }

        private void брэндыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.BringToFront();
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
        }

        private void toolStripButton14_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.taskBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
        }

        private void toolStripButton21_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.reportBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.brandBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
        }

    }
}
