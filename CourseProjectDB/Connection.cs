﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectDB
{
    class Connection {

        public Connection() {}

        public DataTable getConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=True;User ID=root;Password=root;");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from car", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
