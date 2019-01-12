using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StoreSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDBConnection();

            Console.ReadKey();
        }

        private static void TestDBConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user01\source\repos\Practice\StoreSystem\Database1.mdf;Integrated Security=True";

            string sql = "select * from Product";
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Id"]}, {reader["Name"]}, {reader["Price"]}");
                        }
                    }
                }
            }
        }
    }
}
