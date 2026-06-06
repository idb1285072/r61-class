using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Elfie.Serialization;

namespace MVCClient.DTO
{
    public enum Source { Police = 1, Court }
    public class CaseMaster
	{

		public int Id { get; set; }
		[Required, StringLength(20)]
		public string CaseNumber { get; set; } = default!;

		public IFormFile Picture { get; set; }

		[Required, DataType(DataType.Date)]
		public DateTime CaseDate { get; set; }
		
		[Required, StringLength(1000)]
		public string Details { get; set; } = default!;
		public bool Status { get; set; }
        public Source Source { get; set; }
        public IList<CaseDetail> CaseDetails { get; set; } = new List<CaseDetail>();

	}
	public class CaseDetail
	{
		public int Id { get; set; }
		[Required, Column(TypeName = "date")]
		public DateTime CurrentHearingDate { get; set; }
		[Column(TypeName = "date")]
		public DateTime NextHearingDate { get; set; }
		[Required, StringLength(500)]
		public string Comment { get; set; } = default!;
		[ForeignKey("CaseMaster")]
		public int CaseMasterId { get; set; }
		public CaseMaster CaseMaster { get; set; } = default!;
	}
}
