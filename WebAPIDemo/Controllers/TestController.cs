using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            RepositoryData repo = new RepositoryData(new WebAPIDemoContext());

            IQueryable<OrderData> orders = repo.GetAllOrders();

            return View(orders);
        }
    }
}