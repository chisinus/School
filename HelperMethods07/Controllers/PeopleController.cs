using HelperMethods07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods07.Controllers
{
    //document links in mvc
    /*
        Url.Content("∼/Content/Site.css")
        Html.ActionLink("My Link", "Index", "Home")
        Url.Action("GetPeople", "People")
        Url.RouteUrl(new {controller = "People", action="GetPeople"})
        Html.RouteLink("My Link", new {controller = "People", action="GetPeople"})
        Html.RouteLink("My Link", "FormRoute", new {controller = "People", action="GetPeople"})
    */
    public class PeopleController : Controller
    {
        private Person[] personData = {
                                        new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
                                        new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
                                        new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
                                        new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
                                      };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeople()
        {
            return View(personData);
        }

        [HttpPost]
        public ActionResult GetPeople(string selectedRole)
        {
            if (selectedRole == null || selectedRole == "All")
            {
                return View(personData);
            }
            else
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                return View(personData.Where(p => p.Role == selected));
            }
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            // Thread.Sleep(3000);

            return PartialView(GetData(selectedRole));
        }

        public ActionResult GetPeople_Ajax(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }

        private IEnumerable<Person> GetData(string selectedRole)
        {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }

            return data;
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            //if (Request.IsAjaxRequest()) use this to detect if it is a Ajax request or an HTML request

            IEnumerable<Person> people = GetData(selectedRole);
            var data = people.Select(p => new { FirstName = p.FirstName, LastName = p.LastName, Role = Enum.GetName(typeof(Role), p.Role) });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}