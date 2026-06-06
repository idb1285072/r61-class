using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcCore_MasterDetail.Models
{
    public enum Source { Police = 1, Court }
    public class CaseContext : DbContext
    {
        public CaseContext(DbContextOptions options) : base(options)
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

        public string Picture { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime CaseDate { get; set; }
        [Required, EnumDataType(typeof(Source))]
        public Source Source { get; set; }
        [Required, StringLength(1000)]
        public string Details { get; set; } = default!;
        public bool Status { get; set; }




        public List<CaseDetail> CaseDetails { get; set; } = new List<CaseDetail>();
    }
    public class CaseDetail
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yy}",ApplyFormatInEditMode =true)]
        public DateTime CurrentHearingDate { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime NextHearingDate { get; set; }
        [Required, StringLength(500)]
        public string Comment { get; set; } = default!;
        [ForeignKey("CaseMaster")]
        public int CaseMasterId { get; set; }
        public CaseMaster CaseMaster { get; set; } = default!;
    }
}
