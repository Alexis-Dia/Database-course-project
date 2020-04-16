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
    public partial class Main : Form
    {
        const int ADMIN_ROLE_ID = 1;
        const int USER_ROLE_ID = 2;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Connection connection = new Connection();
            String login = textBox1.Text;
            String query = "select * from [carriages_system].[dbo].[user] where login = @login";
            SqlDataAdapter sqlDataAdapter = connection.getConnectionWithCommand(query, login);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            int i = dataTable.Select().Length;

            if (i == 1)
            {
            DataRow row = dataTable.Rows[0];
            String email = row["login"].ToString();
            String password = row["password"].ToString();
            if (textBox1.Text == email && textBox2.Text == password)
            {
                int role_id = Int32.Parse(row["role_id"].ToString());
                if (role_id == USER_ROLE_ID)
                    {
                        UserMainForm userForm = new UserMainForm(this, dataTable);
                        userForm.Show();
                        this.Hide();
                    }
                else
                    {
                        AdminMainForm userForm = new AdminMainForm(this, dataTable);
                        userForm.Show();
                        this.Hide();
                    }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
