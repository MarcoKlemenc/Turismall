using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismall.Data;
using Turismall.Services;

namespace Turismall.Controllers
{
    public class DestinoController : Controller
    {
        private readonly IDestinoService _service;

        public DestinoController(IDestinoService service)
        {
            _service = service;    
        }

        // GET: Destino
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Destino/Details/5
        public IActionResult Details(int? id)
        {
            var destino = _service.GetById(id);
            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }
    }
}
