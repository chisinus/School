using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}