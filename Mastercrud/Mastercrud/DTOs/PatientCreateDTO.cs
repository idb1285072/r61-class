using System.ComponentModel.DataAnnotations;
using static Mastercrud.Models.DbModel;

namespace Mastercrud.DTOs
{
    public class PatientCreateDTO
    {
        public Patient Patient { get; set; }


        public IFormFile PicFile { get; set; }
        //public int Id { get; set; }

        //[Required, StringLength(50)]
        //public string Name { get; set; }

        //[Required, DataType(DataType.Date)]
        //public DateTime BirthDate { get; set; }

        //[Required, StringLength(50)]
        //public string Picture { get; set; }

        //public bool IsAdmited { get; set; }

        //// A Patient can have many Appointments
        //public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
