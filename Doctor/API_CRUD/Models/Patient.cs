using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CRUD.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<PatientAppointment> Appointments { get; set; }
    }
}