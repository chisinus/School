using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UT_Product
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] { new Product {ProductID = 1, Name = "P1"},
                                                                new Product {ProductID = 2, Name = "P2"},
                                                                new Product {ProductID = 3, Name = "P3"},
                                                                new Product {ProductID = 4, Name = "P4"},
                                                                new Product {ProductID = 5, Name = "P5"}
                                                                });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List_WithPage(2).Model;
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List_WithPage(2);
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            //Product[] prodArray = result.ToArray();
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                                                                new Product {ProductID = 1, Name = "P1"},
                                                                new Product {ProductID = 2, Name = "P2"},
                                                                new Product {ProductID = 3, Name = "P3"},
                                                                new Product {ProductID = 4, Name = "P4"},
                                                                new Product {ProductID = 5, Name = "P5"}
                                                            });

            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            // - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] 
                                                {
                                                    new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                                                    new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                                                    new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                                                    new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                                                    new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
                                                });

            // Arrange - create a controller and make the page size 3 items
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Action - test the product counts for different categories
            int res1 = ((ProductsListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((ProductsListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((ProductsListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItems;
            int resAll = ((ProductsListViewModel)controller.List(null).Model).PagingInfo.TotalItems;
            
            // Assert
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}
