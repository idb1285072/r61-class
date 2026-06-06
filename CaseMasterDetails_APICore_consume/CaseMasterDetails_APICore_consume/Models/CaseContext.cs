using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CaseMasterDetails_APICore_consume.Models
{
	public enum Source { Police = 1, Court }
	public class CaseContext:DbContext
	{
        public CaseContext(DbContextOptions options):base(options)
        {
            
        }
		public DbSet<CaseDetail> CaseDetails { get; set; }
		public DbSet<CaseMaster> CaseMasters { get; set; }
	}
	public class CaseMaster
	{
		public int Id { get; set; }
		[Required, StringLength(20)]
		public string CaseNumber { get; set; } = default!;
        [ValidateNever]
        public string? Picture { get; set; }

		[Required, DataType(DataType.Date)]
		public DateTime CaseDate { get; set; }
		[Required, EnumDataType(typeof(Source))]
		public Source Source { get; set; }
		[Required, StringLength(1000)]
		public string Details { get; set; } = default!;
		public bool Status { get; set; }


		[ValidateNever]

		public ICollection<CaseDetail> CaseDetails { get; set; } = new List<CaseDetail>();
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
        [ValidateNever]
        public CaseMaster CaseMaster { get; set; } = default!;
	}
}
