using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAngular.Models
{
    public class SportsStoreContext : DbContext
    {
        public SportsStoreContext()
            : base("SportsStoreContext")
        {
        }

        public DbSet<ProductData> Products { get; set; }
    }
}