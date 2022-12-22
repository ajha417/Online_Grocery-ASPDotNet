using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineGrocery.Models
{
    public class Functions
    {
        private SqlConnection connection;
        private SqlCommand command;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string connString;
        public Functions()
        {
            connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Amit jha\Documents\GroceryStore.mdf"";Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection(connString);
            command = new SqlCommand();
            command.Connection = connection;
         //   command.CommandType = CommandType.Text;
        }

        public DataTable getData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query,connString);
            sda.Fill(dt);
            return dt;
        }
        public int setData(string Qeuery)
        {
            int Cnt = 0;
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            command.CommandText= Qeuery;
            Cnt = command.ExecuteNonQuery();
            connection.Close();
            return Cnt;
        }
    }
}