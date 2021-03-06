﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;

using TheGildedRose.WebAPI.Controllers;
using TheGildedRose.WebAPI.Models;
using TheGildedRose.Data.Repositories;
using TheGildedRose.Data.Models;

namespace TheGildedRose.WebAPI.Tests.Unit.Controllers
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void PlaceOrderTest()
        {
            OrderController controller = CreateController();
            OrderRequest request = new OrderRequest() { MerchantId = "A3D75E02-044B-4909-8E7C-4D6473B814BF", ItemId = "344DD455-691D-4BBB-89A6-A67588DB3172", Quantity = 2 };

            HttpResponseMessage response = controller.Post(request);

            Assert.IsTrue(response.IsSuccessStatusCode);

        }

        [TestMethod]
        public void MissingMechantIdTest()
        {
            OrderController controller = CreateController();
            OrderRequest request = new OrderRequest() { MerchantId = "", ItemId = "344DD455-691D-4BBB-89A6-A67588DB3172", Quantity = 2 };

            HttpResponseMessage response = controller.Post(request);

            Assert.IsTrue(!response.IsSuccessStatusCode);

        }

        [TestMethod]
        public void InvalidItemTest()
        {
            OrderController controller = CreateController();
            OrderRequest request = new OrderRequest() { MerchantId = "A3D75E02-044B-4909-8E7C-4D6473B814BF", ItemId = "344DD455-691D-4BBB-89A6-A67588DB3000", Quantity = 2 };

            HttpResponseMessage response = controller.Post(request);

            Assert.IsTrue(!response.IsSuccessStatusCode);

        }

        private static OrderController CreateController()
        {
            OrderController controller = new OrderController(new OrderRepository(), new InventoryRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            return controller;
        }

    }
}
