using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Turismall.Services;

namespace Turismall.Controllers
{
    [Authorize]
    public class ViajeController : Controller
    {
        private readonly IViajeService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public ViajeController(IViajeService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: Viaje
        public IActionResult Index()
        {
            return View(_service.GetByUser(_userManager.GetUserId(HttpContext.User)));
        }

        // GET: Viaje/Details/5
        public IActionResult Details(int? id)
        {
            var viaje = _service.GetById(id);
            if (viaje == null || viaje.Usuario != _userManager.GetUserId(HttpContext.User))
            {
                return NotFound();
            }
            return View(viaje);
        }

        // GET: Viaje/Create
        public IActionResult Create()
        {
            Viaje viaje = new Viaje
            {
                Nombre = "Viaje sin nombre"
            };
            return View(viaje);
        }

        // POST: Viaje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                viaje.Usuario = _userManager.GetUserId(HttpContext.User);
                _service.Create(viaje);
                _service.Save();
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        // GET: Viaje/Edit/5
        public IActionResult Edit(int? id)
        {
            var viaje = _service.GetById(id);
            if (viaje == null || viaje.Usuario != _userManager.GetUserId(HttpContext.User))
            {
                return NotFound();
            }
            return View(viaje);
        }

        // POST: Viaje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Viaje viaje)
        {
            if (id != viaje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(viaje);
                    _service.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViajeExists(viaje.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        private bool ViajeExists(int id)
        {
            return _service.GetById(id) != null;
        }
    }
}
