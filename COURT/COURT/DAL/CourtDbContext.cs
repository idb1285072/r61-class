using COURT.Models;
using Microsoft.EntityFrameworkCore;

namespace COURT.DAL
{
    public class CourtDbContext:DbContext
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
