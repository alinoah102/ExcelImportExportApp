using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using DataLibrary.Models;

namespace DataLibrary.DataAccessLayer {
    public static class DatabaseHelper {
        private static string connec = "Server=ZeroCool102;Database=KopisShowcase;Trusted_Connection=True;";

        public static string ConnectionStringGet() {
            return connec;
        }

        public static SqlConnection GetSqlConnection() {
            string Conn = ConnectionStringGet();
            using(SqlConnection connection = new SqlConnection(ConnectionStringGet())) {

                connection.Open();
                return connection;
            }
        }
    }
}
