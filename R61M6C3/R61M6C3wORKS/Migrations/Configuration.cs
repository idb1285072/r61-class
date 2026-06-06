namespace R61M6C3wORKS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using R61M6C3wORKS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<R61M6C3wORKS.Models.DbschoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(R61M6C3wORKS.Models.DbschoolContext context)
        {
            var std = new Student
            {
                 Name="Farhan",
                
                 Address="Dhaka",
                  ContactNo="01447784521",
                  Email="f@f.com"
            };
            context.Students.Add(std);
            context.SaveChanges();
        }
    }
}
