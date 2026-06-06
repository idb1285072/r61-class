using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AdmissionDate { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }
        public string? ImageUrl { get; set; }
        public string AddressJson { get; set; }
        public string BaseImage64 { get; set; }
    }

    public class AddressDto
    {
       
        public string City { get; set; }
        public string Street { get; set; }
    }
}
