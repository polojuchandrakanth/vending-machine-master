using System;
using System.Collections.Generic;

namespace Vending
{
    public class VendingMachine
    {
        public Dictionary<string, VendingItem> VendingMachineItems = new Dictionary<string, VendingItem>();
        FileHandler HandleFiles = new FileHandler();

        public Money Money { get; }

        public string NotEnoughMoneyError = "Not enough money in the machine to complete the transaction.";
        public string MessageToUser;

        public VendingMachine()
        {
            this.VendingMachineItems = this.HandleFiles.GetVendingItems();
            this.Money = new Money(string.Empty);
        }

        public decimal MoneyInMachine
        {
            get
            {
                return this.Money.MoneyInMachine;
            }
        }

        public void DisplayAllItems()
        {
            Console.WriteLine($"\n\n{"#".PadRight(5)} {"Stock"} { "Product".PadRight(47) } { "Price".PadLeft(7)}");
            foreach (KeyValuePair<string, VendingItem> kvp in this.VendingMachineItems)
            {
                if (kvp.Value.ItemsRemaining > 0)
                {
                    string itemNumber = kvp.Key.PadRight(5);
                    string itemsRemaining = kvp.Value.ItemsRemaining.ToString().PadRight(5);
                    string productName = kvp.Value.ProductName.PadRight(40);
                    string price = kvp.Value.Price.ToString("C").PadLeft(7);
                    Console.WriteLine($"{itemNumber} {itemsRemaining} {productName} Costs: {price} each");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.ProductName} IS SOLD OUT.");
                }
            }
        }

        public bool ItemExists(string itemNumber)
        {
            return this.VendingMachineItems.ContainsKey(itemNumber);
        }

        public bool RetreiveItem(string itemNumber)
        {
            if (this.ItemExists(itemNumber)
                && this.Money.MoneyInMachine >= this.VendingMachineItems[itemNumber].Price
                && this.VendingMachineItems[itemNumber].ItemsRemaining > 0
                && this.VendingMachineItems[itemNumber].RemoveItem())
            {
                string message = $"{this.VendingMachineItems[itemNumber].ProductName.ToUpper()} {itemNumber}";
                decimal before = this.Money.MoneyInMachine;
                this.Money.RemoveMoney(this.VendingMachineItems[itemNumber].Price);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
