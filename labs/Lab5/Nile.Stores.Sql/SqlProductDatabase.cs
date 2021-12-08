using System;
using System.Collections.Generic;

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

        protected override Product AddCore ( Product product ) => throw new NotImplementedException();
        protected override Product FindByName ( string name ) => throw new NotImplementedException();
        protected override IEnumerable<Product> GetAllCore () => throw new NotImplementedException();
        protected override Product GetCore ( int id ) => throw new NotImplementedException();
        protected override void RemoveCore ( int id ) => throw new NotImplementedException();
        protected override Product UpdateCore ( Product existing, Product newItem ) => throw new NotImplementedException();
    }
}
