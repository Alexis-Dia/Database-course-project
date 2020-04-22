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
        DataTable currentUserDataTable = null;
        DataTable currentTasksTable = null;
        DataTable freeTasksDataTable = null;
        bool userIsActive = false;

        public UserMainForm(Main main, DataTable dataTable)
        {
            InitializeComponent();
            this.main = main;
            this.currentUserDataTable = dataTable;

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

            int userId = (int)row["id"];
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("SELECT * from GetMineCurrentTasks(" + userId + ")");
            DataTable currentTasksTable = new DataTable();
            sqlDataAdapter.Fill(currentTasksTable);
            this.currentTasksTable = currentTasksTable;

            if (currentTasksTable.Rows.Count == 1)
            {
                this.userIsActive = true;
                button2.Enabled = false;
            }
            
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            panel1.BringToFront();
            panel1.Location = new Point(0, 30);
            panel2.SendToBack();
            panel3.SendToBack();
            panel1.Visible = true;
            panel3.Visible = false;
            panel2.Visible = false;
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
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("SELECT * from GetFreeTasks()");
            DataTable freeTasksDataTable = new DataTable();
            sqlDataAdapter.Fill(freeTasksDataTable);
            dataGridView1.DataSource = freeTasksDataTable;
            this.freeTasksDataTable = freeTasksDataTable;

            panel1.SendToBack();
            panel2.BringToFront();
            panel2.Location = new Point(0, 30);
            panel3.SendToBack();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void мояИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("Select * from car");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            panel1.BringToFront();
            panel1.Location = new Point(0, 30);
            panel2.SendToBack();
            panel3.SendToBack();
            panel1.Visible = true;
            panel3.Visible = false;
            panel2.Visible = false;
            //dataGridView1.DataSource = dataTable;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void текущаяЗадачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow row = this.currentUserDataTable.Rows[0];
            int userId = (int) row["id"];
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("SELECT * from GetMineFinishedTasks(" + userId + ")");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            panel1.SendToBack();
            panel2.BringToFront();
            panel2.Location = new Point(0, 30);
            panel3.SendToBack();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void всеОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow row = this.currentUserDataTable.Rows[0];
            int userId = (int)row["id"];
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("SELECT * from GetReportsForActiveTask(" + userId + ")");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;

            Connection connection2 = new Connection();
            SqlDataAdapter sqlDataAdapter2 = connection2.getConnection("SELECT * from GetMineCurrentTasks(" + userId + ")");
            DataTable currentTasksTable = new DataTable();
            sqlDataAdapter2.Fill(currentTasksTable);
            this.currentTasksTable = currentTasksTable;

            panel1.SendToBack();
            panel2.SendToBack();
            panel3.BringToFront();
            panel3.Location = new Point(0, 30);
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;

            if (dataTable.Rows.Count == 0)
            {
                button3.Enabled = false;
            }

        }

        private void добавитьОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.SendToBack();
            panel3.BringToFront();
            panel3.Location = new Point(0, 30);
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void текущаяЗадачаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataRow row = this.currentUserDataTable.Rows[0];
            int userId = (int)row["id"];
            Connection connection = new Connection();
            SqlDataAdapter sqlDataAdapter = connection.getConnection("SELECT * from GetMineCurrentTasks(" + userId + ")");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            panel1.SendToBack();
            panel2.BringToFront();
            panel2.Location = new Point(0, 30);
            panel3.SendToBack();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int taskId = default;
            int weight;
            int distance;
            DateTime departure;
            DateTime arrival;

            if (this.currentTasksTable.Rows.Count == 1)
            {
                DataRow currentTasksTableRow = this.currentTasksTable.Rows[0];
                taskId = (int)currentTasksTableRow["id"];

                if (textBox41.Text != "" && textBox42.Text != "")
                {
                    DataRow userRow = currentUserDataTable.Rows[0];
                    int userId = (int)userRow["id"];

                    weight = Int32.Parse(textBox41.Text);
                    distance = Int32.Parse(textBox42.Text);

                    departure = dateTimePicker1.Value;
                    arrival = dateTimePicker1.Value;

                    DataTable dt = new DataTable();
                    SqlConnection myConn = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=True;User ID=root;Password=root;");
                    myConn.Open();
                    SqlCommand myCmd = new SqlCommand("ADD_REPORT", myConn);
                    myCmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@current_task_id", taskId);
                    SqlParameter param2 = new SqlParameter("@current_user_id", userId);
                    SqlParameter param3 = new SqlParameter("@departure", departure);
                    SqlParameter param4 = new SqlParameter("@weight", weight);
                    SqlParameter param5 = new SqlParameter("@distance", distance);
                    SqlParameter param6 = new SqlParameter("@arrival", arrival);
                    myCmd.Parameters.Add(param1);
                    myCmd.Parameters.Add(param2);
                    myCmd.Parameters.Add(param3);
                    myCmd.Parameters.Add(param4);
                    myCmd.Parameters.Add(param5);
                    myCmd.Parameters.Add(param6);
                    SqlDataAdapter da = new SqlDataAdapter(myCmd);
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;

                    button3.Enabled = true;

                    MessageBox.Show("Отчет был успешно добавлен.");
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            } else
            {
                MessageBox.Show("У пользователя нету активных задач!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int numberOfSelectedRows = dataGridView1.SelectedRows.Count;
            if (numberOfSelectedRows == 1)
            {
                DataRow freeTaskRow = this.freeTasksDataTable.Rows[0];
                int taskId = (int)freeTaskRow["id"];

                DataRow userRow = this.currentUserDataTable.Rows[0];
                int userId = (int)userRow["id"];

                DataTable dt = new DataTable();
                SqlConnection myConn = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=True;User ID=root;Password=root;");
                myConn.Open();
                SqlCommand myCmd = new SqlCommand("TAKE_TASK", myConn);
                myCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@chosen_task_id", taskId);
                SqlParameter param2 = new SqlParameter("@current_user_id", userId);
                myCmd.Parameters.Add(param1);
                myCmd.Parameters.Add(param2);
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                Connection connection = new Connection();
                String query = "select * from [carriages_system].[dbo].[user] where id = " + userId;
                SqlDataAdapter sqlDataAdapter = connection.getConnection(query);
                DataTable currentUserDataTable = new DataTable();
                sqlDataAdapter.Fill(currentUserDataTable);
                this.currentUserDataTable = currentUserDataTable;

                MessageBox.Show("Задача успешно выбрана для выполнения!");
                button2.Enabled = false;
            } else
            {
                MessageBox.Show("Выберите задачу!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.currentTasksTable.Rows.Count == 1)
            {
                DataRow currentTasksTableRow = this.currentTasksTable.Rows[0];
                int taskId = (int)currentTasksTableRow["id"];
                DataTable dt = new DataTable();
                SqlConnection myConn = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=True;User ID=root;Password=root;");
                myConn.Open();
                SqlCommand myCmd = new SqlCommand("SEND_TO_VALIDATION_TASK", myConn);
                myCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@chosen_task_id", taskId);
                myCmd.Parameters.Add(param1);
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                button1.Enabled = false;
                button3.Enabled = false;
                MessageBox.Show("Задача отправлена на валидацию администратором!");
            } else
            {
                MessageBox.Show("У вас нету активной задачи или нету ни одного отчета!");
            }
        }
    }
}
