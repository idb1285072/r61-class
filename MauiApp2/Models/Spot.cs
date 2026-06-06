using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Models
{
    public class Spot
    {
        [Required(ErrorMessage = "Required")]
        public int? SpotId { get; set; }
        public string? SpotName { get; set; }
    }
    public class SpotValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"Spot is Required!", new[] { validationContext.MemberName });
            }

            var spotList = (List<Spot>)value;

            if (!spotList.Any())
            {
                return new ValidationResult($"Spot is Required!", new[] { validationContext.MemberName });
            }

            var invalidSpot = ((List<Spot>)value).Any(x => x.SpotId == null);

            if (!invalidSpot)
            {
                return null;
            }

            return new ValidationResult($"Please select a spot!", new[] { validationContext.MemberName });
        }
    }
}
