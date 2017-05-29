using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismall.Data;
using Turismall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Turismall.Controllers
{
    [Authorize]
    public class ViajeController : Controller
    {
        private readonly IViajeRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ViajeController(IViajeRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        // GET: Viaje
        public IActionResult Index()
        {
            return View(_repository.GetViajesByUser(_userManager.GetUserId(HttpContext.User)));
        }

        // GET: Viaje/Details/5
        public IActionResult Details(int? id)
        {
            var viaje = _repository.GetViajeByID(id);
            if (viaje == null || viaje.Usuario != _userManager.GetUserId(HttpContext.User))
            {
                return NotFound();
            }
            return View(viaje);
        }

        // GET: Viaje/Create
        public IActionResult Create()
        {
            return View();
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
                _repository.InsertViaje(viaje);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        // GET: Viaje/Edit/5
        public IActionResult Edit(int? id)
        {
            var viaje = _repository.GetViajeByID(id);
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
                    _repository.UpdateViaje(viaje);
                    _repository.Save();
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
            return _repository.GetViajeByID(id) != null;
        }
    }
}
