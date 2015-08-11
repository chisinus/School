using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Abstract;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UT_Admin
    {
        [TestMethod]
        public void Index_Contains_All_Products()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
            });

            AdminController controller = new AdminController(mock.Object);

            // Action
            Product[] results = ((IEnumerable<Product>)controller.Index().ViewData.Model).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual("P1", results[0].Name);
            Assert.AreEqual("P2", results[1].Name);
            Assert.AreEqual("P3", results[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product { ProductID = 1, Name = "P1" },
                    new Product { ProductID = 2, Name = "P2" },
                    new Product { ProductID = 3, Name = "P3" }
                });

            AdminController controller = new AdminController(mock.Object);

            // Action
            Product p1 = controller.Edit(1).ViewData.Model as Product;
            Product p2 = controller.Edit(2).ViewData.Model as Product;
            Product p3 = controller.Edit(3).ViewData.Model as Product;

            // Assert
            Assert.AreEqual(1, p1.ProductID);
            Assert.AreEqual(2, p2.ProductID);
            Assert.AreEqual(3, p3.ProductID);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            // Arrange - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                                                                new Product {ProductID = 1, Name = "P1"},
                                                                new Product {ProductID = 2, Name = "P2"},
                                                                new Product {ProductID = 3, Name = "P3"},
                                                            });
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act
            Product result = (Product)target.Edit(4).ViewData.Model;
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            AdminController controller = new AdminController(mock.Object);

            Product product = new Product { Name = "Test" };

            // Act
            ActionResult result = controller.Edit(product);

            // Assert - check that the repository was called
            mock.Verify(m => m.SaveProduct(product));

            // Assert - check the method result type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            AdminController controller = new AdminController(mock.Object);
            controller.ModelState.AddModelError("error", "error");

            Product product = new Product { Name = "Test" };

            // Act - try to save the product
            ActionResult result = controller.Edit(product);

            // Assert - check that the repository was not called
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            // Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            // Arrange
            Product prod = new Product { ProductID = 2, Name = "Test" };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID = 1, Name = "P1" },
                prod,
                new Product { ProductID = 3, Name = "P3" }
            });

            AdminController controller = new AdminController(mock.Object);

            // Action
            controller.Delete(prod.ProductID);

            // Assert
            mock.Verify(m => m.DeleteProduct(prod.ProductID));
        }
    }
}
