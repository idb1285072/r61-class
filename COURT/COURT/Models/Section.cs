using System.ComponentModel.DataAnnotations;

namespace COURT.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string SectionName { get; set; } = default!;
        [Required, StringLength(10)]
        public string SectionNumber { get; set; } = default!;
        public ICollection<CaseMaster> Cases { get; set; } = new List<CaseMaster>();
    }
}
