using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Set_Try
{
    class Database
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=.;Initial Catalog=RegisUser;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
