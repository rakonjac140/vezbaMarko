using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RestoranRepository
    {
        public List<Restoran> GetAllMenuItems()
        {
            List<Restoran> results = new List<Restoran>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Students";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while(sqlDataReader.Read())
                {
                    Restoran r = new Restoran();
                    r.Id = sqlDataReader.GetInt32(0);
                    r.Title = sqlDataReader.GetString(1);
                    r.Description = sqlDataReader.GetString(2);
                    r.Price = sqlDataReader.GetDecimal(3);              
                }
                return results;
            }
        }

        public int InsertMenuItem(Restoran r)
        {
            using(SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO MenuItems VALUES ('{0}','{1}',{2})", r.Title, r.Description, r.Price);
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
