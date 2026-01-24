using BookBarn.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookBarn.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookBarnContext _context;

        public BooksController(BookBarnContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        [Route("Books/Info")]
        public IActionResult About()
        {
            return View();
        }
    }
}