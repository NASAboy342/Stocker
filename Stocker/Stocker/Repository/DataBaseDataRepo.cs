using Stocker.Models;
using Stocker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Stocker.Repository
{
    class DataBaseDataRepo : IDataBaseDataRepo
    {
        private readonly string _connectionString;

        public DataBaseDataRepo()
        {
            _connectionString = ConnectionStringModel.ConnectionString;
        }
        public List<ItemsModels> SelectAllFromItems()
        {
            var connectionString = _connectionString;
            var script = "select * from dbo.Items";
            var table = new List<ItemsModels>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(script, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            table.Add(new ItemsModels()
                            {
                                ItemId = (int)reader["ItemId"],
                                ItemName = (string)reader["ItemName"],
                                Quatity = (int)reader["Quatity"]
                            });
                        }
                    }
                    connection.Close();
                }
            }

            return table;
        }
    }
}
