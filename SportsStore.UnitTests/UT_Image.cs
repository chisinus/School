using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using Moq;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UT_Image
    {
        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            // Arrange
            Product product = new Product
                                    {
                                        ProductID = 2,
                                        Name = "Test",
                                        ImageData = new byte[] { },
                                        ImageMimeType = "image/png"
                                    };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] 
                                                    {
                                                        new Product {ProductID = 1, Name = "P1"},
                                                        product,
                                                        new Product {ProductID = 3, Name = "P3"}
                                                    }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);

            // Act - call the GetImage action method
            ActionResult result = controller.GetImage(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(product.ImageMimeType, ((FileResult)result).ContentType);
        }

        [TestMethod]
        public void Cannot_Retrieve_Image_Data_For_Invalid_ID()
        {
            // Arrange - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] 
                                                    {
                                                        new Product {ProductID = 1, Name = "P1"},
                                                        new Product {ProductID = 2, Name = "P2"}
                                                    }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);

            // Act - call the GetImage action method
            ActionResult result = controller.GetImage(100);

            // Assert
            Assert.IsNull(result);
        }
    }
}
