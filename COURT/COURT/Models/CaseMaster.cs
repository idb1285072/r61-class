using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COURT.Models
{
    public enum Source { S1=1, S2}
    public class CaseMaster
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string CaseNumber { get; set; } = default!;

        [Required, ForeignKey(nameof(Section))]
        public int SectionId { get; set; } = default!;
        public Section Section { get; set; } = default!;

        [Required, DataType(DataType.Date)]
        public DateTime CaseDate { get; set; }
        [Required, EnumDataType(typeof(Source))]
        public Source Source { get; set; }
        [Required, StringLength(1000)]
        public string Details {  get; set; }=default!;
        public bool Status { get; set; }
        [Required, ForeignKey(nameof(Court))]
        public int CourtId { get; set; }
        public Court Court { get; set; } = default!;
        [Required, ForeignKey(nameof(CaseDetail))]
        public int CaseDetailId {  get; set; }
        public ICollection<CaseDetail> CaseDetails { get; set; } = new List<CaseDetail>();
    }
}
