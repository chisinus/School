using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
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

        // Simple
        //public ViewResult List()
        //{
        //    return View(repository.Products);
        //}

        // always return all
        //public ViewResult List(int page = 1)
        //{
        //    //return View(List_WithPage(page));
        //    return View(List_WithPageControl(page));
        //}
        // With Page
        //public IEnumerable<Product> List_WithPage(int page = 1)
        //{
        //    return repository.Products
        //                     .OrderBy(p => p.Description)
        //                     .Skip((page - 1) * PageSize)
        //                     .Take(PageSize);
        //}

        //// With page control
        //public ProductsListViewModel List_WithPageControl(int page = 1)
        //{
        //    ProductsListViewModel model = new ProductsListViewModel
        //    {
        //        Products = repository.Products
        //                            .OrderBy(p => p.Description)
        //                            .Skip((page - 1) * PageSize)
        //                            .Take(PageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PageSize,
        //            TotalItems = repository.Products.Count()
        //        }
        //    };

        //    return model;
        //}

        public ViewResult List(string category, int page = 1)
        {
            return View(List_WithPageControl(category, page));
        }


        // With page control
        public ProductsListViewModel List_WithPageControl(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                                    .Where(p => category == null || p.Category == category)
                                    .OrderBy(p => p.Description)
                                    .Skip((page - 1) * PageSize)
                                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                },
                CurrentCategory = category
            };

            return model;
        }
    }
}