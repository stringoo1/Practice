namespace StoreSystem.Entity
{
    public class Stock
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        public Stock(int id, int quantity)
        {
            this.ProductId = id;
            this.Quantity = quantity;
        }
    }
}
