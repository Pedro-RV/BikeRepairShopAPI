namespace Sale_Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sale_Data.Context.SaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(Sale_Data.Context.SaleContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        //    //  to avoid creating duplicate seed data.
        //}
    }
}
