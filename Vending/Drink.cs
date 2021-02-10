namespace Vending
{
    public class Drink : VendingItem
    {
        public const string Message = "Glug";

        public Drink(
            string productName,
            decimal price,
            int itemsRemaining)
                : base(
                productName,
                price,
                itemsRemaining,
                Message)
        {
        }
    }

}
