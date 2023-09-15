using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistApp.Data;
using PlaylistApp.Models;
using System.Diagnostics;

namespace PlaylistApp.Controllers
{
    public class HomeController : Controller
    {

        // private readonly ILogger<HomeController> _logger;

        // public HomeController( ILogger<HomeController> logger)
        // {
        //   _logger = logger;
        // }

        private readonly PlaylistDbContext _context;

        public HomeController(PlaylistDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Artists != null ?
            View(await _context.Artists.ToListAsync()) :
            Problem("Entity set 'PlaylistDbContext.Artists'  is null.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}