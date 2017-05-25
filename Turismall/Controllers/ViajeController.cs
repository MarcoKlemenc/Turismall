using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turismall.Data;
using Turismall.Models;
using Microsoft.AspNetCore.Identity;

namespace Turismall.Controllers
{
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
            if (User.Identity.IsAuthenticated)
            {
                return View(_repository.GetViajesByUser(_userManager.GetUserId(HttpContext.User)));
            }
            return Redirect("Account/Login");
        }

        // GET: Viaje/Details/5
        public IActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var viaje = _repository.GetViajeByID(id);
                if (viaje == null || viaje.Usuario != _userManager.GetUserId(HttpContext.User))
                {
                    return NotFound();
                }

                return View(viaje);
            }
            return Redirect("../../Account/Login");
        }

        // GET: Viaje/Create
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return Redirect("../Account/Login");
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
            if (User.Identity.IsAuthenticated)
            {
                var viaje = _repository.GetViajeByID(id);
                if (viaje == null || viaje.Usuario != _userManager.GetUserId(HttpContext.User))
                {
                    return NotFound();
                }
                return View(viaje);
            }
            return Redirect("../../Account/Login");
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
