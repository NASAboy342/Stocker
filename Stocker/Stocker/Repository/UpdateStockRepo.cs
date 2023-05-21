using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocker.Models;
using Stocker.Models.Response;
using System.Data.SqlClient;
using System.Data;

namespace Stocker.Repository
{
    class UpdateStockRepo
    {
        public void UpdateStock(UpdateStockRequest req)
        {
            var connectionString = ConnectionStringModel.ConnectionString;
            var spName = SpUpdateStock.spName;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(spName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(SpUpdateStock.updateDate, req.UpdateDate);
                    command.Parameters.AddWithValue(SpUpdateStock.input, req.Input);
                    command.Parameters.AddWithValue(SpUpdateStock.outPut, req.Output);
                    command.Parameters.AddWithValue(SpUpdateStock.itemId, req.ItemId);

                    var result = 0;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int)reader["return"];
                        }
                    }

                    connection.Close();
                    if (result == 2)
                    {
                        throw new Exception("Stock is not enough/ចំនួនទំនិញមិនគ្រប់គ្រាន់!");
                    }
                }
            }
        }
    }
}
