using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TheGildedRose.WebAPI.Controllers;
using TheGildedRose.Data.Repositories;
using TheGildedRose.Data.Models;

namespace TheGildedRose.WebAPI.Tests.Unit.Controllers
{
    [TestClass]
    public class InventoryControllerTests
    {
        [TestMethod]
        public void Get()
        {
            InventoryController controller = new InventoryController(new InventoryRepository());
            IEnumerable<Item> result = controller.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(11, result.Count());

        }
    }
}
