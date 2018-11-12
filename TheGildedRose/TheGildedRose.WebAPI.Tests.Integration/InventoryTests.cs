using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RestSharp;

namespace TheGildedRose.WebAPI.Tests.Integration
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void GetInventory()
        {
            RestClient client = new RestClient("http://localhost:50156/api/inventory");
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("apikey", "52212679-87F3-484B-893B-C7329F74876A");
            IRestResponse response = client.Execute(request);

            Assert.IsTrue(response.IsSuccessful);

        }
    }
}
