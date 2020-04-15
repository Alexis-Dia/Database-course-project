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
            String s = row["login"].ToString();
            if (textBox1.Text == s && textBox2.Text == "alex")
            {
                UserForm userForm = new UserForm(this);
                userForm.Show();
                this.Hide();
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
    }
}
