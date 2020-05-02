using System;
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

        public SqlDataAdapter getConnection(String query)
        {
            SqlConnection connection = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=False;User ID=root;Password=root;");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            return sqlDataAdapter;
        }

        public SqlDataAdapter getConnectionWithCommand(String query, String param)
        {
            SqlConnection connection = new SqlConnection("Data Source=ADRUZIK-PC\\SQLEXPRESS;Initial Catalog=carriages_system;Integrated Security=False;User ID=root;Password=root;");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@login", param);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            return sqlDataAdapter;
        }
    }
}
