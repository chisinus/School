using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRespository)
        {
            repository = productRespository;
        }

        //public ViewResult List()
        //{
        //    return View(repository.Products);
        //}

        public ViewResult List(int page=1)
        {
            return View(repository.Products
                                        .OrderBy(p => p.Description)
                                        .Skip((page - 1) * PageSize)
                                        .Take(PageSize));
        }
    }
}