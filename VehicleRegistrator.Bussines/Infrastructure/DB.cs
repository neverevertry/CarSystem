using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VehicleRegistrator.Bussines
{
    public class DB
    {
        public SqlConnection ConnectDB()
        {
            string connectionString = @"Data Source=SPEED;Integrated Security=True;Initial Catalog = VehicleCar;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                string ExMassage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
             return connection;
        }
    }
}
