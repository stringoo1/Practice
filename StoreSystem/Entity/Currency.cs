using System;

namespace StoreSystem.Entity
{
    public class Currency
    {
        //
        public readonly string Name;
        public readonly int Price;

        private Currency(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public static Currency Parse(string name)
        {
            if (name == NameYen1) return Yen1;
            if (name == NameYen10) return Yen10;
            if (name == NameYen50) return Yen50;
            if (name == NameYen100) return Yen100;
            if (name == NameYen500) return Yen500;
            if (name == NameYen1000) return Yen1000;

            throw new Exception("");

        }

        private const string NameYen1 = "1円";
        private const string NameYen10 = "10円";
        private const string NameYen50 = "50円";
        private const string NameYen100 = "100円";
        private const string NameYen500 = "500円";
        private const string NameYen1000 = "1000円";

        public static readonly Currency Yen1 = new Currency(NameYen1, 1);
        public static readonly Currency Yen10 = new Currency(NameYen1, 10);
        public static readonly Currency Yen50 = new Currency(NameYen1, 50);
        public static readonly Currency Yen100 = new Currency(NameYen1, 100);
        public static readonly Currency Yen500 = new Currency(NameYen1, 500);
        public static readonly Currency Yen1000 = new Currency(NameYen1, 1000);



    }
}
