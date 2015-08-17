using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions06.Controllers
{
    public class DerivedController : Controller
    {
        // GET: Derived
        public ActionResult Index()
        {
            ViewBag.Message = "Hello from the DerivedController Index method";

            return View("MyView");
        }

        public ActionResult GetParameters()
        {
            //from context
            string userName = User.Identity.Name;
            string serverName = Server.MachineName;
            string clientIP = Request.UserHostAddress;
            DateTime dateStamp = HttpContext.Timestamp;

            //AuditRequest(userName, serverName, clientIP, dateStamp);

            // from Request.Form
            string oldProductName = Request.Form["OldName"];
            string newProductName = Request.Form["NewName"];

            //bool result = AttemptProductRename(oldProductName, newProductName);
            //ViewData["RenameResult"] = result;

            // Another way from context
            string city = (string)RouteData.Values["City"];
            DateTime forDate = DateTime.Parse(Request.Form["forDate"]);

            return View();
        }

        // Better for Unit Test
        public ActionResult UserParameters(string city, DateTime forDate)
        {
            return View();
        }
    }
}