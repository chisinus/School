using MyAngular.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MyAngular.Controllers.API
{
    public class SportsStoreWebAPIController : ApiController
    {
        private static OrderData order;
        private List<ProductData> products = new List<ProductData>()
        {
            new ProductData {ID = 1, Name="Product #1", Description ="A Product 1", Category="Category #1", Price=100 },
            new ProductData {ID = 2, Name="Product #2", Description ="A Product 2", Category="Category #1", Price=110 },
            new ProductData {ID = 3, Name="Product #3", Description ="A Product 3", Category="Category #2", Price=210 },
            new ProductData {ID = 4, Name="Product #4", Description ="A Product 4", Category="Category #3", Price=202 }
        };

        [HttpGet]
        public List<ProductData> GetProducts()
        {
            return products;
        }

        [HttpPost]
        public void NewOrder(OrderData newOrder)
        {
            order = newOrder;
        }
    }
}