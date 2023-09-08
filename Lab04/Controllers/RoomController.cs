using Lab04.Data;
using Lab04.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab04.Controllers
{
    public class RoomController : Controller
    {
        private readonly CRContext _context;

        public RoomController(CRContext context)
        {
            _context = context;
        }

        // GET: RoomController
        public async Task<IActionResult> Index()
        {
            return _context.Rooms != null ?
                        View(await _context.Rooms.ToListAsync()) :
                        Problem("Entity set 'CRContext.Room'  is null.");
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Capacity", "Section")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: RoomController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int roomNumber, [Bind("Capacity", "Section")] Room room)
        {

            if (roomNumber != room.RoomNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        private bool RoomExists(int number)
        {
            return (_context.Rooms?.Any(r => r.RoomNumber == number)).GetValueOrDefault();
        }
    }
}
