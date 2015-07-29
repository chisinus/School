using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class WebAPIDemoContext : DbContext
    {
        public WebAPIDemoContext()
            : base("name=WebAPIDemoContext")
        {
            Debug.Write(Database.Connection.ConnectionString);
        }

        public DbSet<BookData> Books { get; set; }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderDetailData> OrderDetails { get; set; }
    }
}