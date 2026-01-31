using BookBarn.Models;
using Microsoft.AspNetCore.Mvc;
using BookBarn.ViewModels;

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

            var vm = new AuthorListViewModel
            {
                Authors = authors,
                PageTitle = "Authors",
                TotalCount = authors.Count,
                EmptyMessage = "No authors found."
            };

            return View(vm);
        }
        [Route("Authors/Info")]
        public IActionResult Details()
        {
            return View();
        }
    }
}
