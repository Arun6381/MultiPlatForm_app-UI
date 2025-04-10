using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class SqlProductService : IProductService
    {  
        private readonly string _connectionString = "Server=1qaz2wsx\\121211;Database=#@*;Trusted_Connection=True;TrustServerCertificate=true";

        public async Task<List<Product>> GetProductsAsync()
        {
            List<Product> products = new();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Name, Price, Description FROM dbo.Product";
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        Description = reader.GetString(3)
                    });
                }
            }

            return products;
        }
    }
}
