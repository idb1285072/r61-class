using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MvcCore_MasterDetail.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcCore_MasterDetail.DTO
{
    public class CaseMaster
    {

        public int Id { get; set; }
        [Required, StringLength(20)]
        public string CaseNumber { get; set; } = default!;

        public IFormFile Picture { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime CaseDate { get; set; }

        [Required, StringLength(1000)]
        public string Details { get; set; } = default!;
        public bool Status { get; set; }
        [Required, EnumDataType(typeof(Source))]
        public Source Source { get; set; }
        [ValidateNever]
        public IList<CaseDetail> CaseDetails { get; set; } = new List<CaseDetail>();

    }
    public class CaseDetail
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime CurrentHearingDate { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime NextHearingDate { get; set; }
        [Required, StringLength(500)]
        public string Comment { get; set; } = default!;
        [ForeignKey("CaseMaster")]
        public int CaseMasterId { get; set; }
        [ValidateNever]
        public CaseMaster CaseMaster { get; set; } = default!;
    }
}
