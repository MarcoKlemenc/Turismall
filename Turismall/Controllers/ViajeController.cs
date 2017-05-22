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
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ViajeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Viaje
        public IActionResult Index()
        {
            return View(_context.Viaje.Where(x => x.Usuario == _userManager.GetUserId(HttpContext.User)));
        }

        // GET: Viaje/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = _context.Viaje
                .SingleOrDefault(m => m.ID == id);
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
                _context.Add(viaje);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        // GET: Viaje/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = _context.Viaje.SingleOrDefault(m => m.ID == id);
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
                    _context.Update(viaje);
                    _context.SaveChanges();
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

        // GET: Viaje/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = _context.Viaje
                .SingleOrDefault(m => m.ID == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // POST: Viaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var viaje = _context.Viaje.SingleOrDefault(m => m.ID == id);
            _context.Viaje.Remove(viaje);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool ViajeExists(int id)
        {
            return _context.Viaje.Any(e => e.ID == id);
        }
    }
}
