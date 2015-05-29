﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageFeatures.Models;
using Moq;

namespace LanguageFeatures.Tests
{
    [TestClass]
    public class UT_LinqValueCalculator
    {
        private Product[] products = {new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                                      new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                                      new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                                      new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
};
        [TestMethod]
        public void Sum_Products_Correctly()
        {
            //arrange
            var discounter = new MinimumDiscountHelper();
            var target = new LinqValueCalculator(discounter);

            var goalTotal = products.Sum(e => e.Price);

            //act
            var result = target.ValueProducts(products);

            //assert
            Assert.AreEqual(goalTotal, result);
        }

        [TestMethod]
        public void Sum_Products_Correctly_Moq()
        {
            //arrange
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);

            var goalTotal = products.Sum(e => e.Price);

            //act
            var result = target.ValueProducts(products);

            //assert
            Assert.AreEqual(goalTotal, result);
        }
    }
}