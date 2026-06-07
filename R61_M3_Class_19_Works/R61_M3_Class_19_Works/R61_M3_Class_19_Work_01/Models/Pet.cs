using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_19_Work_01.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string Color { get; set; }
        public int OwnerId {  get; set; }
    }
}
