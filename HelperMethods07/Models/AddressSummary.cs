using HelperMethods07.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods07.Models
{
    //[Bind(Include="City")] for all action, only City will be bound
    [ModelBinder(typeof(AddressSummaryBinder))]     // use custom model binder
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}