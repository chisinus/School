﻿using MyAngular.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyAngular.Controllers
{
    public class SportsStoreController : Controller
    {
        // GET: SportsStore
        public ActionResult Home()
        {
            return View();
        }

        private List<ProductData> products = new List<ProductData>()
        {
            new ProductData {Name="Product #1", Description ="A Product 1", Category="Category #1", Price=100 },
            new ProductData {Name="Product #2", Description ="A Product 2", Category="Category #1", Price=110 },
            new ProductData {Name="Product #3", Description ="A Product 3", Category="Category #2", Price=210 },
            new ProductData {Name="Product #4", Description ="A Product 4", Category="Category #3", Price=202 }
        };

        //[HttpGet]
        //public List<ProductData> GetProducts()
        //{
        //    return products;
        //}
        public int[] GetProducts()
        {
            return new int[] { 1, 2, 3 };
        }

    }
}