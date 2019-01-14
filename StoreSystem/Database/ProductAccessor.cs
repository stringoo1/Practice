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
                    int volume = (int)reader.GetFieldValue<int>(reader.GetOrdinal("Volume"));

                    return new Product(id, name, price, volume);
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


        //private static void DBC01()
        //{
        //    List<Product> products;
        //    using (var accessor = new ProductAccessor())
        //    {
        //        products = accessor.SelectProducts();
        //    }

        //    products.ForEach(a => Console.WriteLine($"{a.ID}, {a.Name}, {a.Price}"));
        //    Console.WriteLine("-----");
        //}

        //private static void DBC02()
        //{
        //    int recordCount;

        //    using (var accessor = new ProductAccessor())
        //    {
        //        recordCount = accessor.SelectProducts().Count;
        //    }

        //    recordCount++;

        //    using (var accessor = new ProductAccessor())
        //    {
        //        accessor.InsertProducts(new Product(recordCount, "test" + recordCount, recordCount * 13));
        //    }
        //}



    }
}
