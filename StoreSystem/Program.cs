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
            using (var system = new StoreSystem())
            {
                system.Run();
            }

            Console.ReadKey();
        }

    }
}
