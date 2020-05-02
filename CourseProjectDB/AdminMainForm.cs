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

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carriages_systemDataSet.FullUserView' table. You can move, or remove it, as needed.
            //this.fullUserViewTableAdapter.Fill(this.carriages_systemDataSet.FullUserView);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.user_status' table. You can move, or remove it, as needed.
            this.user_statusTableAdapter.Fill(this.carriages_systemDataSet.user_status);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.carriages_systemDataSet.user);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.carriages_systemDataSet.user);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.task_status' table. You can move, or remove it, as needed.
            this.task_statusTableAdapter.Fill(this.carriages_systemDataSet.task_status);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.task_report' table. You can move, or remove it, as needed.
            this.task_reportTableAdapter.Fill(this.carriages_systemDataSet.task_report);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.task' table. You can move, or remove it, as needed.
            this.taskTableAdapter.Fill(this.carriages_systemDataSet.task);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.role' table. You can move, or remove it, as needed.
            this.roleTableAdapter.Fill(this.carriages_systemDataSet.role);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.carriages_systemDataSet.report);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.car_status' table. You can move, or remove it, as needed.
            this.car_statusTableAdapter.Fill(this.carriages_systemDataSet.car_status);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.car' table. You can move, or remove it, as needed.
            this.carTableAdapter.Fill(this.carriages_systemDataSet.car);
            // TODO: This line of code loads data into the 'carriages_systemDataSet.brand' table. You can move, or remove it, as needed.
            this.brandTableAdapter.Fill(this.carriages_systemDataSet.brand);

            panel1.BringToFront();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();

        }

        private void brandBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.brandBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.carBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.carstatusBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.reportBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.roleBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.taskBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton42_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.taskreportBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton49_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.taskstatusBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton56_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.userBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton63_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.userstatusBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton70_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.fullUserViewBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void брэндыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void машиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.BringToFront();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void статусыМашинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.BringToFront();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.BringToFront();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void ролиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.BringToFront();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void задачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.BringToFront();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void задачиотчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.BringToFront();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void статусыОтчетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.BringToFront();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.SendToBack();
            panel10.BringToFront();
            panel11.SendToBack();
        }

        private void статусыПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.SendToBack();
            panel4.SendToBack();
            panel5.SendToBack();
            panel6.SendToBack();
            panel7.SendToBack();
            panel8.SendToBack();
            panel9.BringToFront();
            panel10.SendToBack();
            panel11.SendToBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView5.CurrentCell.RowIndex;
            if (rowIndex != 0)
            {
                int selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView5.Rows[selectedrowindex];
                int taskId = (int)selectedRow.Cells[1].Value;
                int taskStatus = (int)selectedRow.Cells[5].Value;

                if (taskStatus == 3)
                {
                    DataTable dt = new DataTable();
                    SqlConnection myConn = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=False;User ID=root;Password=root;");
                    myConn.Open();
                    SqlCommand myCmd = new SqlCommand("VALIDATE_TASK_TO_FINISHED", myConn);
                    myCmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@chosen_task_id", taskId);
                    myCmd.Parameters.Add(param1);
                    SqlDataAdapter da = new SqlDataAdapter(myCmd);
                    da.Fill(dt);
                    dataGridView5.DataSource = dt;

                    this.userTableAdapter.Fill(this.carriages_systemDataSet.user);
                    try
                    {
                        this.Validate();
                        this.fullUserViewBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.carriages_systemDataSet);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Задача была успешно отвалидирована.");
                }
                else
                {
                    MessageBox.Show("Выберите задычу, со статусом 'VALIDATING'!");
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numberOfSelectedRows = dataGridView5.SelectedRows.Count;
            if (numberOfSelectedRows == 1)
            {
                int selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView5.Rows[selectedrowindex];
                int taskId = (int) selectedRow.Cells[1].Value;
                int taskStatus = (int) selectedRow.Cells[5].Value;

                if (taskStatus == 3)
                {
                    DataTable dt = new DataTable();
                    SqlConnection myConn = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=False;User ID=root;Password=root;");
                    myConn.Open();
                    SqlCommand myCmd = new SqlCommand("VALIDATE_TASK_TO_REJECTED", myConn);
                    myCmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@chosen_task_id", taskId);
                    myCmd.Parameters.Add(param1);
                    SqlDataAdapter da = new SqlDataAdapter(myCmd);
                    da.Fill(dt);
                    dataGridView5.DataSource = dt;
                    MessageBox.Show("Задача успешно отклонена.");
                } else
                {
                    MessageBox.Show("Выберите задычу, со статусом 'VALIDATING'!");
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу!");
            }
        }
    }
}
