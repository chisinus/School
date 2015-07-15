﻿using System;
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
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List_WithPage(2);

            // Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
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

            // Act
            //ProductsListViewModel result = (ProductsListViewModel)controller.List_WithPageControl(2).Model;
            ProductsListViewModel result = (ProductsListViewModel)controller.List_WithPageControl(2);

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);

            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}