/*
 * Jett Smith
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Nile.Stores.Sql
{
    /// <summary>Prodvides a SQL Server implementaion of <see cref="IProductDatabase"/>.</summary>
    public class SqlProductDatabase : ProductDatabase
    {
        private readonly string _connectionString;

        public SqlProductDatabase (string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override Product AddCore ( Product product )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                //Get movie ID as result
                object result = cmd.ExecuteScalar();
                product.Id = Convert.ToInt32(result);
            }

            return product;
        }

        protected override Product FindByName ( string name )
        {
            var products = GetAll();

            foreach (Product product in products)
            {
                if (product.Name.Equals(name))
                {
                    return new Product {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        IsDiscontinued = product.IsDiscontinued,
                    };
                }
            }

            return null;
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    yield return new Product() {
                        Id = row.Field<int>("Id"),
                        Name = row.Field<string>("Name"),
                        Price = row.Field<decimal>("Price"),
                        Description = row.Field<string>("Description"),
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                    };
                }
            }
        }

        protected override Product GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product() {
                            Id = reader.GetFieldValue<int>("Id"),
                            Name = reader.GetFieldValue<string>("Name"),
                            Price = reader.GetFieldValue<decimal>("Price"),
                            Description = reader.GetFieldValue<string>("Description"),
                            IsDiscontinued = reader.GetFieldValue<bool>("IsDiscontinued"),
                        };
                    }
                }
            }

            return null;
        }
        
        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

                cmd.ExecuteNonQuery();
            }

            return newItem;
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
    }
}
