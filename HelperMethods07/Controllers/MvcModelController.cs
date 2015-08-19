using HelperMethods07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods07.Controllers
{
    public class MvcModelController : Controller
    {
        private Person[] personData =   {
                                            new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
                                            new Person {PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
                                            new Person {PersonId = 3, FirstName = "John", LastName = "Smith", Role = Role.User},
                                            new Person {PersonId = 4, FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
                                        };

        // GET: MvcModel
        public ActionResult Index(int id = 1)
        {
            //1.Request.Form["id"]
            //2.RouteData.Values["id"]
            //3.Request.QueryString["id"]
            //4.Request.Files["id"]

            Person person = personData.Where(p => p.PersonId == id).First();

            return View(person);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("Index", person);
        }

        //public ActionResult DisplaySummary([Bind(Prefix ="HomeAddress", Exclude ="Country")]AddressSummary summary)
        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)   // can also be IList<string>， IList<AddressSummary> etc.
        {
            names = names ?? new string[0];

            return View(names);
        }

        //        public ActionResult Addresses(FormCollection formData)
        //        {
        //            IList<AddressSummary> addresses = new List<AddressSummary>();
        //            //UpdateModel(addresses, new FormValueProvider(ControllerContext)); //without formData parameter
        //            try
        //            {
        //                UpdateModel(addresses, formData);
        //            }
        //            catch (InvalidOperationException ex)
        //            {
        //                // provide feedback to user
        //            }

        //            //or 
        //            if (TryUpdateModel(addresses, formData))
        //            {
        //                // proceed as normal
        //}
        //            else
        //            {
        //                // provide feedback to user
        //            }

        //            return View(addresses);
        //        }

        // custom binding provider
        public ActionResult Addresses()
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            UpdateModel(addresses);

            return View(addresses);
        }

    }
}