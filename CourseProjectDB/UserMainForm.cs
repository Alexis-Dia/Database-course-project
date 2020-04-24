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
        Connection connection = new Connection();
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
            textBox17.Text = row["name"].ToString();

            panel1.BringToFront();
            panel2.SendToBack();

            int userId = (int)row["id"];
            SqlDataAdapter sqlDataAdapter = this.connection.getConnection("SELECT * from GetMineCurrentTasks(" + userId + ")");
            DataTable currentTasksTable = new DataTable();
            sqlDataAdapter.Fill(currentTasksTable);
            this.currentTasksTable = currentTasksTable;

            sqlDataAdapter = this.connection.getConnection("SELECT * FROM cariages_min_max_distance_view ORDER BY distance DESC;");
            DataTable maxDistanceTable = new DataTable();
            sqlDataAdapter.Fill(maxDistanceTable);
            dataGridView3.Columns.Add("newColumnName", "Водитель");
            dataGridView3.Columns.Add("newColumnName", "Дистанция");
            DataGridViewColumn column1 = dataGridView3.Columns[0];
            DataGridViewColumn column2 = dataGridView3.Columns[1];
            column1.Width = 130;
            column2.Width = 135;
            for (int i = 0; i < maxDistanceTable.Rows.Count; i++)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells[0].Value = maxDistanceTable.Rows[i]["driverId"].ToString();
                dataGridView3.Rows[i].Cells[1].Value = maxDistanceTable.Rows[i]["distance"].ToString();
            }

            sqlDataAdapter = this.connection.getConnection("SELECT * FROM cariages_car_count_view;");
            DataTable maxDeparturesTable = new DataTable();
            sqlDataAdapter.Fill(maxDeparturesTable);
            dataGridView4.Columns.Add("newColumnName", "Авто");
            dataGridView4.Columns.Add("newColumnName", "Количество выездов");
            DataGridViewColumn column3 = dataGridView4.Columns[0];
            DataGridViewColumn column4 = dataGridView4.Columns[1];
            column3.Width = 148;
            column4.Width = 150;
            for (int i = 0; i < maxDeparturesTable.Rows.Count; i++)
            {
                dataGridView4.Rows.Add();
                dataGridView4.Rows[i].Cells[0].Value = maxDeparturesTable.Rows[i]["name"].ToString();
                dataGridView4.Rows[i].Cells[1].Value = maxDeparturesTable.Rows[i]["departureCount"].ToString();
            }

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
            SqlDataAdapter sqlDataAdapter = this.connection.getConnection("SELECT * from GetFreeTasks()");
            DataTable freeTasksDataTable = new DataTable();
            sqlDataAdapter.Fill(freeTasksDataTable);
            dataGridView1.DataSource = freeTasksDataTable;
            dataGridView1.Columns[0].Visible = false;
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
            SqlDataAdapter sqlDataAdapter = this.connection.getConnection("Select * from car");
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
            SqlDataAdapter sqlDataAdapter = this.connection.getConnection("SELECT * from GetMineFinishedTasks(" + userId + ")");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;

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
            SqlDataAdapter sqlDataAdapter = this.connection.getConnection("SELECT * from GetReportsForActiveTask(" + userId + ")");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            dataGridView2.Columns[0].Visible = false;

            SqlDataAdapter sqlDataAdapter2 = this.connection.getConnection("SELECT * from GetMineCurrentTasks(" + userId + ")");
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
            SqlDataAdapter sqlDataAdapter = this.connection.getConnection("SELECT * from GetMineCurrentTasks(" + userId + ")");
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;

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

                String query = "select * from [carriages_system].[dbo].[FullUserView] where id = " + userId;
                SqlDataAdapter sqlDataAdapter = this.connection.getConnection(query);
                DataTable currentUserDataTable = new DataTable();
                sqlDataAdapter.Fill(currentUserDataTable);
                this.currentUserDataTable = currentUserDataTable;

                DataRow row = this.currentUserDataTable.Rows[0];
                textBox17.Text = row["name"].ToString();

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
