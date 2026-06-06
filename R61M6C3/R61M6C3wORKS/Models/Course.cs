using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace R61M6C3wORKS.Models
{
    public class Course
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}