using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vending;

namespace VendingTests
{
    [TestClass]
    public class FileHandlerTests
    {
        [TestMethod]
        public static void TestIfItemsImportProperyly()
        {
            FileHandler fileHandler = new FileHandler();

            Dictionary<string, VendingItem> items = fileHandler.GetVendingItems();
            VendingItem item = new Chip("Chip", 0.50M, 5);
            Assert.AreEqual(item, items["A1"]);
        }
}
}
