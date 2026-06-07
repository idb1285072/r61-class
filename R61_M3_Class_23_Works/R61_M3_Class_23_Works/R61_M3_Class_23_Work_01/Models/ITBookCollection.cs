using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_01.Models
{
    public class ITBookCollection<T> : IEnumerable<T> where T : ITBook
    {
        List<ITBook> books = new List<ITBook> ();
        public void Add(T book)
        {
            books.Add (book);
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach(var b in books)
            {
                yield return b as T;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
