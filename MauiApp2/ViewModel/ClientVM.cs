using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MauiApp2.Models;

namespace MauiApp2.ViewModel
{
    public class ClientVM
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? ClientName { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Phone no is required")]
        public int? PhoneNo { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "Picture is required")]
        public string? Picture { get; set; }

        public bool MaritalStatus { get; set; }

        [SpotValidation]
        public List<Spot> SpotList { get; set; } = new List<Spot>();
    }
}
