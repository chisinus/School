﻿using HelperMethods07.Infrastructure;
using HelperMethods07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelperMethods07
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());    //comment out, use custom model binder
            // ModelBinders.Binders.Add(typeof(AddressSummary), new AddressSummaryBinder());       //this or in the class
        }
    }
}
