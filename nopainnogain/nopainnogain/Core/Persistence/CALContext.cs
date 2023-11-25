using Core.Productadministration;
using Core.Useradministration.entities;
using System.Data.Entity;

namespace Core.Persistence
{

    public class CALContext : DbContext
    {
        public CALContext() : base("CAL_DataBase")
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CALContext, Core.Migrations.Configuration>());
        }

        public DbSet<User> UsersDB { get; set; }
        public DbSet<Product> ProductsDB { get; set; }
        public DbSet<Consumption> ConsumptionsDB { get; set; }
        public DbSet<Weight> WeightsDB { get; set; }

    }
}
