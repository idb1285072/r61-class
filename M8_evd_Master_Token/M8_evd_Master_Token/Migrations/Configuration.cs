namespace M8_evd_Master_Token.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using M8_evd_Master_Token.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<M8_evd_Master_Token.Models.DbInvContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(M8_evd_Master_Token.Models.DbInvContext context)
        {
            var userManagre = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new DbInvContext()));
            userManagre.Create(new IdentityUser
            {
                UserName="a@a.com",
                Email= "a@a.com",
                PhoneNumber="01445563216",
                
            },"@Ps123");
            userManagre.Create(new IdentityUser
            {
                UserName = "b@b.com",
                Email = "b@b.com",
                PhoneNumber = "01445563216",

            }, "@Ps123");
            context.Products.AddRange(
                new List<Product>
                {
                    new Product { Name="P1" },
                    new Product { Name="P2" },
                    new Product { Name="P3" } }   );
            context.Sales.Add(new Models.Sales
            {
                Name = "C1",
                Odate = DateTime.Now,
                Status = true,
                Pic = "~/Pictures/1.jpeg",
                Details = new List<Models.Details>{
               new Models.Details{Pid=1,Oid=1,Price=343},new Models.Details{Pid=2,Oid=1,Price=333} }
            });
            context.SaveChanges();


        }
    }
}
