using DotNetFlix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetFlix.Controllers
{
    public class HomeController : Controller
    {
        private readonly DflixContext _context;



        public HomeController(DflixContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            return View(await movies.ToListAsync());
        }

        public IActionResult Reset()
        {
            return View(_context.Movies);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}