using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class ShoppingCart : IEnumerable<Product>
    {
        private IValueCalculator calc;

        public ShoppingCart()
        {
        }

        public ShoppingCart(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public List<Product> Products { get; set; }

        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }

    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> cartParam)
        {
            return cartParam.Sum(p=>p.Price);
        }

        public static IEnumerable<Product> FiterByPrice(this IEnumerable<Product> productEnum, decimal price)
        {
            foreach (Product prod in productEnum)
            {
                if (prod.Price > price)
                    yield return prod;
            }
        }

        public static IEnumerable<Product> FilterByFunction(this IEnumerable productEnum, Func<Product, bool> filterFunc)
        {
            foreach (Product prod in productEnum)
            {
                if (filterFunc(prod))
                    yield return prod;
            }
        }
    }
}