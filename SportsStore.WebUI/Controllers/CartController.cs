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
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        #region Use browser Session
        //public ViewResult Index(string returnUrl)
        //{
        //    return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl});
        //}

        //public RedirectToRouteResult AddToCart(int productID, string returnUrl)
        //{
        //    Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

        //    if (product != null)
        //        GetCart().AddItem(product, 1);

        //    return RedirectToAction("Index", new { returnUrl });
        //}

        //public RedirectToRouteResult RemoveFromCart(int productID, string returnUrl)
        //{
        //    Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
        //    if (product != null)
        //        GetCart().RemoveLine(product);

        //    return RedirectToAction("Index", new { returnUrl });
        //}

        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }

        //    return cart;
        //}
        #endregion Use browser Session

        #region use model binder
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

            if (product != null)
                cart.AddItem(product, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
                cart.RemoveLine(product);

            return RedirectToAction("Index", new { returnUrl });
        }
        #endregion use model binder

        #region Cart Summary
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        #endregion Cart Summary
    }
}