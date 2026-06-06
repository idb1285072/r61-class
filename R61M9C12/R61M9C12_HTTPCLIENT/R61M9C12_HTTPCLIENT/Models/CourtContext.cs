using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace R61M9C12_HTTPCLIENT.Models
{
     
    public enum Source { Police = 1, Court }
    public class Section
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string SectionName { get; set; } = default!;
        [Required, StringLength(10)]
        public string SectionNumber { get; set; } = default!;
        public ICollection<CaseMaster> Cases { get; set; } = new List<CaseMaster>();
    }
    public class Court
    {
        public int CourtId { get; set; }
        [Required, StringLength(50)]
        public string CourtName { get; set; } = default!;
        public ICollection<CaseMaster> Cases { get; set; } = new List<CaseMaster>();
    }

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
        public string Details { get; set; } = default!;
        public bool Status { get; set; }
        [Required, ForeignKey(nameof(Court))]
        public int CourtId { get; set; }
        public Court Court { get; set; } = default!;
       
       
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
        public CaseMaster CaseMaster { get; set; } = default!;
    }
    public class CourtDbContext : DbContext
    {
        public CourtDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CaseDetail> CaseDetails { get; set; }
        public DbSet<CaseMaster> CaseMasters { get; set; }
    }
}
