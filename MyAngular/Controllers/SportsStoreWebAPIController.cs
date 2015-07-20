using MyAngular.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MyAngular.Controllers
{
    public class SportsStoreWebAPIController : ApiController
    {
        private List<ProductData> products = new List<ProductData>()
        {
            new ProductData {Name="Product #1", Description ="A Product 1", Category="Category #1", Price=100 },
            new ProductData {Name="Product #2", Description ="A Product 2", Category="Category #1", Price=110 },
            new ProductData {Name="Product #3", Description ="A Product 3", Category="Category #2", Price=210 },
            new ProductData {Name="Product #4", Description ="A Product 4", Category="Category #3", Price=202 }
        };

        // GET: SportsStoreWebAPI
        [HttpGet]
        public List<ProductData> GetProducts()
        {
            return products;
        }
    }
}