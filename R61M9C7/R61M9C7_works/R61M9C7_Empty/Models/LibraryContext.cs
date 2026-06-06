using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace R61M9C7_Empty.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
    }

    public class BookAuthor
    {
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Author")]
        public int AuthorID
        {
            get; set;
        }
        [DataType(DataType.Date,ErrorMessage ="Please Provide proper date"),DisplayFormat(DataFormatString ="{0:dd-MM-YY}",ApplyFormatInEditMode =true)]
        public DateTime PublishedDate { get; set; }
        [ValidateNever]
        public Book Book { get; set; }
        [ValidateNever]
        public Author Author { get; set; }
    }
        public class Book
        {
            public int Id { get; set; }
                [StringLength(50)]
            public string Name { get; set; }
            public string? BookImage { get; set; }
            public string? Description { get; set; }
            public double Price { get; set; }
            public bool IsAvailable { get; set; }
        }

        public class Author
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Contact
            {
                get; set;
            }
            public string? AuthorImage { get; set; }

        }
    }

