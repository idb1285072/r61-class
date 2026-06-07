using R61_M3_Class_22_Work_01.Models;
using R61_M3_Class_22_Work_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_22_Work_01.Tests
{
    public class DIThroughConstructorBook
    {
        IGenericRepository<Book> repo;
        public DIThroughConstructorBook(IGenericRepository<Book> repo)
        {
            this.repo = repo;
        }
        public void Run()
        {
            //Data insert
            this.repo.Insert(new Book {  Id = 1, Title= "C#", CoverPrice=730.00M, PublishDate=new DateTime(1999, 7, 1)});
            this.repo.InsertRange(new Book[]
            {
                new Book {  Id = 2, Title= "SQL", CoverPrice=850.00M, PublishDate=new DateTime(1999, 7, 1)},
                new Book {  Id = 3, Title= "HTML", CoverPrice=360.00M, PublishDate=new DateTime(1999, 7, 1)}
            });
            //Get
            this.repo.GetAll()
                .ToList()
                .ForEach(b =>
                {
                    Console.WriteLine($"{b.Title} price: {b.CoverPrice}, published {b.PublishDate:yyyy-MMM-dd}");
                });
            Console.WriteLine();
            //Get one
            var bk = this.repo.GetById(2);
            //Update
            bk.CoverPrice = 1150.00M;
            this.repo.Update(bk);
            this.repo.GetAll()
                .ToList()
                .ForEach(b =>
                {
                    Console.WriteLine($"{b.Title} price: {b.CoverPrice}, published {b.PublishDate:yyyy-MMM-dd}");
                });
            Console.WriteLine();
            //Delete
            this.repo.Delete(2);
            this.repo.GetAll()
                .ToList()
                .ForEach(b =>
                {
                    Console.WriteLine($"{b.Title} price: {b.CoverPrice}, published {b.PublishDate:yyyy-MMM-dd}");
                });
            Console.WriteLine();
        }
    }
}
