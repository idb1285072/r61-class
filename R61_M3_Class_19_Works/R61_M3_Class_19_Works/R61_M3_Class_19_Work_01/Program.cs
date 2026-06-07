using R61_M3_Class_19_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_19_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Owner> owners = new List<Owner> { 
                new Owner{ OwnerId=1, OwnerName="OW1", Contact="01717XXXXXX"},
                new Owner{ OwnerId=2, OwnerName="OW2", Contact="01817XXXXXX"},
                new Owner{ OwnerId=3, OwnerName="OW3", Contact="01317XXXXXX"},
                new Owner{ OwnerId=4, OwnerName="OW4", Contact="01617XXXXXX"},
                new Owner{ OwnerId=5, OwnerName="OW5", Contact="01917XXXXXX"}
            };
            List<Pet> pets = new List<Pet> { 
                new Pet{PetId=1, PetName="Buch", PetType="Dog", OwnerId=1, Color="Brown"},
                new Pet{PetId=2, PetName="Milo", PetType="Dog", OwnerId=1, Color="Black"},
                new Pet{PetId=3, PetName="Trek", PetType="Dog", OwnerId=3, Color="Gray"},
                new Pet{PetId=4, PetName="Otto", PetType="Dog", OwnerId=3, Color="Black"},
                new Pet{PetId=5, PetName="Ditto", PetType="Dog", OwnerId=3, Color="Red"},
                new Pet{PetId=6, PetName="Silo", PetType="Dog", OwnerId=4, Color="Black"},
                new Pet{PetId=7, PetName="Britt", PetType="Dog", OwnerId=5, Color="White"}
            };
            //Query
            var q1 = from o in owners                    
                     join p in pets on o.OwnerId equals p.OwnerId 
                     select new { o, p};
            foreach (var q in q1)
            {
                Console.WriteLine($"{q.o.OwnerName}, {q.o.Contact}");
                Console.WriteLine($"\t{q.p.PetName}, {q.p.PetType}, {q.p.Color}");
            }
            Console.WriteLine();
            owners.Join(pets,
                o => o.OwnerId,
                p => p.OwnerId,
                (o, p) => new { o, p })
                .ToList()
                .ForEach(q =>
                {
                    Console.WriteLine($"{q.o.OwnerName}, {q.o.Contact}");
                    Console.WriteLine($"\t{q.p.PetName}, {q.p.PetType}, {q.p.Color}");
                });

            //Find the owner information of the pet named Buch
            Console.WriteLine();
            var oid = (from p in pets
                       where p.PetName == "Buch"
                       select p.OwnerId).First();
            var ow = (from o in owners
                      where o.OwnerId == oid
                      select o).First();
            Console.WriteLine($"{ow.OwnerName}, {ow.Contact}");
            Console.WriteLine();
            var oid1 = pets.First(p => p.PetName == "Buch").OwnerId;
            var ow1 = owners.First(o=> o.OwnerId == oid1);
            Console.WriteLine($"{ow1.OwnerName}, {ow1.Contact}");
            Console.WriteLine();
            //Grouping
            var q2 = from p in pets
                     group p by p.OwnerId into g
                     select g;
            foreach (var q in q2)
            {
                //Console.WriteLine(q.Key);
                var owner = (from o in owners
                             where o.OwnerId == q.Key
                             select o).First();
                Console.WriteLine($"{owner.OwnerName}, {owner.Contact}");
                foreach (var p in q)
                {
                    Console.WriteLine($"\t{p.PetName}, {p.PetType}, {p.Color}");
                } 
            }
            Console.WriteLine();
            pets.GroupBy(o => o.OwnerId).Select(g => g)
                .ToList()
                .ForEach(g =>
                {
                    //Console.WriteLine($"{g.Key}");
                    var owner = owners.First(o => o.OwnerId == g.Key);
                    Console.WriteLine($"{owner.OwnerName}, {owner.Contact}");
                    g.ToList()
                    .ForEach(p =>
                    {
                        Console.WriteLine($"\t{p.PetName}, {p.PetType}, {p.Color}");
                    });
                });
            Console.ReadLine();
        }
    }
}
