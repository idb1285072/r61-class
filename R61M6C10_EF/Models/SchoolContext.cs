using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace R61M6C10_EF.Models
{
    public class SchoolContext:IdentityDbContext
    {
        public SchoolContext():base("defaultconnection")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}