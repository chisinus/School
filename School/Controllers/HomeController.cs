using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good Afternoon";

            return View();
        }

        [HttpGet]
        public ViewResult SubscribeForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SubscribeForm(UserData user)
        {
            if (!ModelState.IsValid)
                return View();

            return View("Confirmation", user);
        }
	}
}