using System.Collections.Generic;
using StoreSystem.Entity;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace StoreSystem.Database
{
    public class ProductAccessor : AccessorBase
    {
        // レコード全件を対象に、ID値の最大を求める
        public int GetMaxProductId()
        {
            return SelectProducts().Select(elm => elm.ID).Max();
        }

        // レコード全件を取得する
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

        // レコードを挿入する
        public void InsertProduct(string name, int price)
        {
            string sqlQuery = @"
insert into Product(
    Id, Name, Price )
values(
    @Id, @Name, @Price)
";
            List<SqlParameter> parameters = new List<SqlParameter>();
            int id = GetMaxProductId() + 1;

            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@Name", name));
            parameters.Add(new SqlParameter("@Price", price));

            this.ExecuteNonQuery(
                sqlQuery,
                parameters
                );
        }
    }
}
