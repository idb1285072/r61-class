using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNo { get; set; }
        public string Picture { get; set; }
        public bool MaritalStatus { get; set; }
        public List<BookingEntry> BookingEntries { get; set; } = new List<BookingEntry>();
    }
}
