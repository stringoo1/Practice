using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StoreSystem.Database;
using StoreSystem.Entity;

namespace StoreSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            DBC01();
            DBC02();
            DBC01();

            Console.ReadKey();
        }

        private static void DBC01()
        {
            List<Product> products;
            using (var accessor = new ProductAccessor())
            {
                products = accessor.SelectProducts();
            }

            products.ForEach(a => Console.WriteLine($"{a.ID}, {a.Name}, {a.Price}"));
            Console.WriteLine("-----");
        }

        private static void DBC02()
        {
            int recordCount;

            using (var accessor = new ProductAccessor())
            {
                recordCount = accessor.SelectProducts().Count;
            }

            recordCount++;

            using (var accessor = new ProductAccessor())
            {
                accessor.InsertProducts(new Product(recordCount, "test" + recordCount, recordCount * 13));
            }
        }
        
    }
}
