using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_21_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection col = new MyCollection();
            foreach (string s in col)
            {
                Print(s);
            }
            Console.WriteLine();
            //
            List<int> list = new List<int> { 8, 2, 5, 9 };
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine();
            //
            MyStringCollection col1 = new MyStringCollection();
            col1.Add("H");
            col1.Add("A");
            col1.Add("B");
            col1.Add("I");
            foreach (string s in col1)
            {
                Console.WriteLine($"{s}");
            }
            Console.ReadLine();
        }

        private static void Print(string s)
        {
            Console.WriteLine(MakLower(s));
        }

        private static string MakLower(string s)
        {
            return s.ToLower();
        }

        public class MyCollection : IEnumerable<string>
        {
            public IEnumerator<string> GetEnumerator()
            {
                yield return "H";
                yield return "A";
                yield return "Q";
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        public class MyStringCollection : IEnumerable<string>
        {
            List<string> list = new List<string>();
            public void Add(string s)
            {
                list.Add(s);
            }
            public void Remove(string s)
            {
                list.Remove(s);
            }
            public IEnumerator<string> GetEnumerator()
            {
                return list.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return list.GetEnumerator ();
            }
        }
    }
}