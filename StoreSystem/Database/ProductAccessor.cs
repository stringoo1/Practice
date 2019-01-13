using System.Collections.Generic;
using StoreSystem.Entity;
using System.Data.SqlClient;

namespace StoreSystem.Database
{
    public class ProductAccessor : AccessorBase
    {
        public int SelectCountProducts()
        {
            return SelectProducts().Count;
        }

        public List<Product> SelectProducts()
        {
            string sqlQuery = @"select * from Product";

            return this.ExecuteReader(
                sqlQuery,
                null,
                reader =>
                {
                    int id = (int)reader.GetFieldValue<int>(reader.GetOrdinal("Id"));
                    string name = reader.GetFieldValue<string>(reader.GetOrdinal("Name")).TrimEnd();
                    int price = (int)reader.GetFieldValue<int>(reader.GetOrdinal("Price"));

                    return new Product(id, name, price);
                }
                );
        }

        public void InsertProducts(Product product)
        {
            string sqlQuery = @"
insert into Product(
    Id, Name, Price )
values(
    @Id, @Name, @Price)
";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", product.ID));
            parameters.Add(new SqlParameter("@Name", product.Name));
            parameters.Add(new SqlParameter("@Price", product.Price));

            this.ExecuteNonQuery(
                sqlQuery,
                parameters
                );
        }

    }
}
