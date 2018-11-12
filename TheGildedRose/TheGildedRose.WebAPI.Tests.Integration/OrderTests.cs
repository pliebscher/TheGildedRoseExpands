using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RestSharp;

namespace TheGildedRose.WebAPI.Tests.Integration
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void PlaceOrder()
        {

            RestClient client = new RestClient("http://localhost:50156/api/order");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("apikey", "52212679-87F3-484B-893B-C7329F74876A");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"merchantId\": \"344dd455-691d-4bbb-89a6-a67588db3173\",\r\n  \"itemId\": \"344dd455-691d-4bbb-89a6-a67588db3173\",\r\n  \"quantity\": 3\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Assert.IsTrue(response.IsSuccessful);

        }
    }
}
