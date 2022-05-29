using Lego.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lego.Controllers
{
    public class BOOKS
    {
        public int BK_ID;
        public string BK_Name;
    }
    public class READERS_BOOKS
    {
        public int RB_ID;
        public int RB_RD;
        public int RB_BK;
        public DateTime RB_ISSUE;
    }
    public class LibraryContext : DbContext
    {
        public DbSet<BOOKS> BOOKS;
        public DbSet<READERS_BOOKS> READERS_BOOKS;
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly LibraryContext _context;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<ActionResult<List<BOOKS>>> GetBooks(int id)
        {
            if (_context.BOOKS == null)
                return NotFound();
            //Шукаємо книжки, які брав заданий читач в заданий проміжок
            var books = await (from rb in _context.READERS_BOOKS
                                 join b in _context.BOOKS on rb.RB_BK equals b.BK_ID
                                 where rb.RB_ISSUE >= new DateTime(2021, 9, 1) && rb.RB_ISSUE < new DateTime(2022, 2, 24) 
                                    && rb.RB_RD == id
                                 select b).ToListAsync();
            return books;
        }
    }
}