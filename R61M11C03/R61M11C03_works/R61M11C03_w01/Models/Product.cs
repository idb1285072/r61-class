using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R61M11C03_w01.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int CatId { get; set; }
        [Required, StringLength(50)]
        public string Picture { get; set; }
        [ValidateNever]
        public virtual Category Category { get; set; }

    }
}
