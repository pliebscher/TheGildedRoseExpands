using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheGildedRose.WebAPI;
using TheGildedRose.WebAPI.Controllers;

namespace TheGildedRose.WebAPI.Tests.Unit.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
