using BookBarn.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookBarn.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookBarnContext _context;
        public AuthorsController(BookBarnContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();    
            return View();
        }
        [Route("Authors/Info")]
        public IActionResult Details()
        {
            return View();
        }
    }
}
