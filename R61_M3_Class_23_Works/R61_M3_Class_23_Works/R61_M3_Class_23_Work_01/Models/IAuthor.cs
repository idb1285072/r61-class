using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_01.Models
{
    public interface IAuthor
    {
        string GetAuthors<T>() where T : Book;
    }
}
