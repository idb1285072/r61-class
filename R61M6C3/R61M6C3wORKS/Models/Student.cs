using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace R61M6C3wORKS.Models
{
    [Table("StudentInfo")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StdntID { get; set; }
        [Required]
        [MaxLength(20),MinLength(5)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(15)]
        [Column("Mobile")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        [StringLength (15)]
        public string Email { get; set; }




    }
}