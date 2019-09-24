using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementApp.DAL.Gateway
{
    public class ConnectionGateway
    {
        public SqlConnection connection { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataReader reader { get; set; }

        public ConnectionGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["StockManagmentDBConString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

    }
}