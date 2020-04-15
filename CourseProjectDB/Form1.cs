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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Connection connection = new Connection();
            DataTable dataTable = connection.getConnection();
            foreach (DataRow row in dataTable.Rows)
            {
                String s = row["number"].ToString();
                MessageBox.Show(s);
            }
        }
    }
}
