using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD.Models
{
    public class Degree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DoctorsDegree> DoctorsDegrees { get; set; }
    }
}