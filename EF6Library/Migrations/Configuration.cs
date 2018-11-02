using System.Data.Entity.Migrations;
using EF6Library.EFClasses;

namespace EF6Library.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EF6DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EF6Library.EFClasses.EF6DbContext";
        }

        protected override void Seed(EF6DbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}