using System.ComponentModel.DataAnnotations;

namespace R61M9C12_MVCClient.DTOs
{
    public class CourtVM
    {
        public int CourtId { get; set; }
        [Required, StringLength(50)]
        public string CourtName { get; set; } 
    }
}
