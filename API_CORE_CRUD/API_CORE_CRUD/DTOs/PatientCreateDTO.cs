using API_CORE_CRUD.Models;

namespace API_CORE_CRUD.DTOs
{
    public class PatientCreateDTO
    {
        public Patient Patient { get; set; }
        public IFormFile PicFile { get; set; }
    }
}
