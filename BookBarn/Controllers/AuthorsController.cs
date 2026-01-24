using Microsoft.AspNetCore.Mvc;

namespace BookBarn.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Authors/Info")]
        public IActionResult Details()
        {
            return View();
        }
    }
}
