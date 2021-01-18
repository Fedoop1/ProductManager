using ProductView.IOController;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductView.Migrations
{
    class Configuration : DbMigrationsConfiguration<ProductView.IOController.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProductView.IOController.ProductContext";
        }

        protected override void Seed(ProductView.IOController.ProductContext context)
        {

        }
    }
}
