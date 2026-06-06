using Microsoft.AspNetCore.Mvc;
using R61M9C7_Empty.Models;

namespace R61M9C7_Empty.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;
        IWebHostEnvironment _environment;
        public BooksController(LibraryContext context, IWebHostEnvironment environment)
        {
            this._context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book,IFormFile BookPic)
        {
            if(BookPic != null)
            {
               //var p= _environment.ContentRootPath;
                var root= _environment.WebRootPath;
                string ext= Path.GetExtension(BookPic.FileName).ToLower();
                if(ext ==".jpg"|| ext ==".png"|| ext == ".jpeg")
                {
                    string filetoSave= Path.Combine(root,"Pictures","Book",book.Name+ext);
                    using(FileStream fs= new FileStream(filetoSave,FileMode.Create))
                    {
                       
                        BookPic.CopyTo(fs);
                    }
                    book.BookImage = Path.Combine("Pictures", "Book", book.Name + ext);
                    book.BookImage ="~/Pictures/Book/"+ book.Name + ext;
                    _context.Books.Add(book);
                    if(_context.SaveChanges()>0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Save Failed ");
                        return View(book);

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please provide  valid Image ");
                    return View(book);
                }

            }
            else
            {
                ModelState.AddModelError("", "Please provide Image");
                return View(book);
            }

           
        }
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return BadRequest("please provide Id");
            }
            var model = _context.Books.Find(id);
            if(model != null)
            {
                return View(model);
            }
            return BadRequest("Not found ");
        }
        [HttpPost]
        public IActionResult Edit(Book book, IFormFile BookPic)
        {
            if (BookPic != null)
            {
                //var p= _environment.ContentRootPath;
                var root = _environment.WebRootPath;
                string ext = Path.GetExtension(BookPic.FileName).ToLower();
                if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                {
                    string filetoSave = Path.Combine(root, "Pictures", "Book", book.Name + ext);
                    using (FileStream fs = new FileStream(filetoSave, FileMode.Create))
                    {

                        BookPic.CopyTo(fs);
                    }
                    book.BookImage = Path.Combine("Pictures", "Book", book.Name + ext);
                    book.BookImage = "~/Pictures/Book/" + book.Name + ext;
                    
                }
                else
                {
                    //ModelState.AddModelError("", "Please provide  valid Image ");
                    //return View(book);
                    book.BookImage = book.BookImage;
                }
                //_context.Books.Add(book);
                _context.Entry(book).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                if (_context.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Save Failed ");
                    return View(book);

                }
            }
            else
            {
                ModelState.AddModelError("", "Please provide Image");
                return View(book);
            }

          
        }
        public IActionResult Delete(int id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
