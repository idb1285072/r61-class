using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD.Models
{
    public class Designation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}