using System;
using System.Data;
using System.Data.SqlClient;


namespace DoAn_LTQL 
{
    public class DataProvider
    {
       
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

    
       string connectionString = @"Server=.;Database=QuanLyCafe;Trusted_Connection=True;TrustServerCertificate=True;";
   
        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    data.Load(reader);
                }
                connection.Close();
            }
            return data;
        }
    }
}