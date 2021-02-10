namespace Vending
{
    public class Candy : VendingItem
    {
        public const string Message = "Munch";

        public Candy(
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
