using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace R61M11C01_ConsumeWEBAPI_IMAGE.ViewModels
{
    public class PersonVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
       
        public IFormFile Image { get; set; }
    }
}
