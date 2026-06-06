namespace WebApplication1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.modelEVD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.modelEVD context)
        {
            context.Products.AddRange(
                new List<Product>
                {
                    new Product{ Name="P1"},
                    new Product{ Name="P2"},
                    new Product{ Name="P3"},
                    new Product{ Name="P4"},
                }                );
            context.SalesOrders.Add(new SalesOrder
            {
                Customername = "Tamim",
                ISCompleted = true,
                OrderDate = DateTime.Now,
                Ordernumber = "0005",
                Picture = "~/Pictures/tamim.jpg",
                 Details=new List<SalesOrderDetail>
                 {
                      new SalesOrderDetail{ OrderId=1, ProductId=1, Quantity=20,
                       UnitPrice=2, Discount= 5, Total=35},
                       new SalesOrderDetail{ OrderId=1, ProductId=2, Quantity=2,
                       UnitPrice=20, Discount= 5, Total=35}

                 }


            });
            context.SaveChanges();
        }
    }
}
