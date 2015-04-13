using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private static int count;

        public LinqValueCalculator()
        {
        }

        private IDiscountHelper discounter;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
            Debug.WriteLine(string.Format("Instance {0} created", ++count));
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            //return products.Sum(p => p.Price);
            return discounter.ApplyDiscount(products.Sum(p => p.Price));

        }
    }
}