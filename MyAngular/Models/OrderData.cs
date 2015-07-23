using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAngular.Models
{
    public class OrderData
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string GiftWrap { get; set; }
        public List<ProductData> Products { get; set; }
    }
}