using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem.Entity
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(int id, string name, int price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        }
    }
}
