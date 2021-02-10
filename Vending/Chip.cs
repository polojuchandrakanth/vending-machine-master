namespace Vending
{
    public class Chip : VendingItem
    {
        public const string Message = "Crunch";

        public Chip(
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
