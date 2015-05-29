using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275M
        };

        private List<Product> products = new List<Product>  { 
                                                                new Product {Name = "Kayak", Category = "Watersports", Price = 100},
                                                                new Product {Name = "Lifejacket", Category = "Watersports", Price = 200},
                                                                new Product {Name = "Soccer ball", Category = "Soccer", Price = 300},
                                                                new Product {Name = "Corner flag", Category = "Soccer", Price = 400}
                                                            };


        private IValueCalculator calc;

        #region constructors
        //public HomeController(IValueCalculator calcParam)
        //{
        //    calc = calcParam;
        //}

        public HomeController(IValueCalculator calcParam, IValueCalculator calc2)   // Demostrates scope
        {
            calc = calcParam;
        }
        #endregion constructors

        #region basic
        //
        // GET: /Home/
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            // create a new Product object
            Product myProduct = new Product();

            // set the property value
            myProduct.Name = "Kayak";

            // get the property
            string productName = myProduct.Name;

            // generate the view
            return View("Result", (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            Product myProduct = new Product();

            // set the property values
            myProduct.ProductID = 100;
            myProduct.Name = "Kayak";
            myProduct.Price = 250M;

            return View("Result", (object)String.Format("Product Name: {0}", myProduct.Name));
        }
        #endregion basic

        #region Use Extension
        public ViewResult UseExtension()
        {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart { Products = products };

            // get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseExtensionFilter()
        {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = products
            };

            // get the total value of the products in the cart
            IEnumerable<Product> result = cart.FiterByPrice(200);

            return View("Result", (object)String.Format("Products above 200: {0}", result.Count()));
        }

        
        public ViewResult UseExtensionFilterByFunction()
        {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product> { new Product {Name = "Kayak", Price = 100},
                                               new Product {Name = "Lifejacket", Price = 200},
                                               new Product {Name = "Soccer ball", Price = 300},
                                               new Product {Name = "Corner flag", Price = 400}
                                             }
            };

            //Func<Product, bool> filterFunc = delegate(Product prod)
            //{
            //    return prod.Price > 200;
            //};
            Func<Product, bool> filterFunc = p => p.Price > 200;

            // get the total value of the products in the cart
            IEnumerable<Product> result = cart.FilterByFunction(filterFunc);

            return View("Result", (object)String.Format("Products above 200: {0}", result.Count()));
        }
        #endregion Use Extension

        #region model
        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;

            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            Product[] array = {
                                new Product {Name = "Kayak", Price = 275M},
                                new Product {Name = "Lifejacket", Price = 48.95M},
                                new Product {Name = "Soccer ball", Price = 19.50M},
                                new Product {Name = "Corner flag", Price = 34.95M}
                              };
            return View(array);
        }
        #endregion model

        #region DI Container
        public ActionResult DemoLinqValueCalculator()
        {
            calc = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            return View(cart.CalculateProductTotal());
        }

        public ActionResult DemoLinqValueCalculatorNinject()
        {
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View("DemoLinqValueCalculator", totalValue);
        }

        public ActionResult DemoLinqValueCalculatorNinjectDependencyResolver()
        {
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            return View("DemoLinqValueCalculator", cart.CalculateProductTotal());
        }
        #endregion DI Container
    }
}
