using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Models
{
    public class BookingEntry
    {
        public int BookingEntryId { get; set; }
        public int ClientId { get; set; }
        public int SpotId { get; set; }

        public Client Client { get; set; }
        public Spot Spot { get; set; }
    }
}
