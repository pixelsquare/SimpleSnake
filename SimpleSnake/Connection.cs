using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace SimpleSnake
{
    public class Connection
    {
        public static SqlConnection cn;
        public static void OpenConnection()
        {
            cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
            cn.Open();
        }

        public static void CloseConnection()
        {
            cn.Close();
        }
    }
}