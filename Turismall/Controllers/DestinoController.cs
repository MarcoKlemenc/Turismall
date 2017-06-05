using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismall.Data;

namespace Turismall.Controllers
{
    public class DestinoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Destino
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destino.ToListAsync());
        }

        // GET: Destino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destino
                .SingleOrDefaultAsync(m => m.ID == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        private bool DestinoExists(int id)
        {
            return _context.Destino.Any(e => e.ID == id);
        }
    }
}
