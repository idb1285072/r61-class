using R61_M3_Class_23_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITBookCollection<ITBook> books = new ITBookCollection<ITBook> ();
            var b1 = new ITBook { ID = 1, Title = "C# Basics", Price=1170.00M, Publisher = "C Publication", PublishDate = DateTime.Today.AddDays(-300) };
            b1.Authors.Add("Mr C");
            b1.Authors.Add("Mr Sharp");
            b1.Tags.Add("Programming");
            b1.Tags.Add(".NET");
            books.Add (b1);
            var b2 = new ITBook { ID = 1, Title = "SQ2",Price=980.00M, Publisher = "DB Pub", PublishDate = DateTime.Today.AddDays(-400) };
            b2.Authors.Add("Mr S");
            b2.Authors.Add("Mr QL");
            b2.Tags.Add("Database");
            b2.Tags.Add("SQL");
            books.Add(b2);
            foreach (var book in books) { 
                Console.WriteLine($"{book.Title}, {book.Price}");
                Console.WriteLine($"Authored by: {book.GetAuthors<ITBook>()}");
                Console.WriteLine($"{book.GetTags<ITBook>()}");
            }
            Console.ReadLine();
        }
    }
}
