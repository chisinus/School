using SportsStore.Domain.Entities;
using System.Data.Entity;
using System.Diagnostics;

namespace SportsStore.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        //public EFDbContext() : base("name=EFDbContext") { Database.SetInitializer<EFDbContext>(null); }
        //public EFDbContext() : base("name=EFDbContext") { Database.SetInitializer<EFDbContext>(null); Debug.Write(Database.Connection.ConnectionString); }
        

        public DbSet<Product> Products { get; set; }
    }
}
