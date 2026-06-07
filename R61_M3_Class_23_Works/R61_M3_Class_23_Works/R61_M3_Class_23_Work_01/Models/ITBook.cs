using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_01.Models
{
    public class ITBook : Book, IAuthor, ITag
    {
        public ICollection<string> Tags { get; set; }=new List<string>();

        public string GetAuthors<T>() where T : Book
        {
            return string.Join(",", Authors);
        }

        public string GetTags<T>() where T : Book
        {
            return string.Join(",", Tags);
        }
    }
}
