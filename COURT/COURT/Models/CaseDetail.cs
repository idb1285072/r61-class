using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COURT.Models
{
    public class CaseDetail
    {
        public int Id { get; set; }
        [Required,Column(TypeName = "date")]
        public DateTime CurrentHearingDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime NextHearingDate { get; set; }
        [Required, StringLength(500)]
        public string Comment { get; set; } = default!;
        public CaseMaster CaseMaster { get; set; } = default!;
    }
}
