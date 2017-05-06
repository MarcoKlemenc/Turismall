using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turismall.Data;
using Turismall.Models;

namespace Turismall.Controllers
{
    public class ViajeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViajeController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Viaje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Viaje.ToListAsync());
        }

        // GET: Viaje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viaje
                .SingleOrDefaultAsync(m => m.ID == id);
            if (viaje == null)
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
        public async Task<IActionResult> Create([Bind("ID,Nombre,Descripcion")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viaje);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        // GET: Viaje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viaje.SingleOrDefaultAsync(m => m.ID == id);
            if (viaje == null)
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Descripcion")] Viaje viaje)
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
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viaje
                .SingleOrDefaultAsync(m => m.ID == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // POST: Viaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viaje = await _context.Viaje.SingleOrDefaultAsync(m => m.ID == id);
            _context.Viaje.Remove(viaje);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ViajeExists(int id)
        {
            return _context.Viaje.Any(e => e.ID == id);
        }

        // GET: Viaje/Note/5
        public async Task<IActionResult> Note(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viaje.SingleOrDefaultAsync(m => m.ID == id);
            if (viaje == null)
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
        public async Task<IActionResult> Note(int id, [Bind("ID,Nombre,Descripcion")] Viaje viaje)
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
                    await _context.SaveChangesAsync();
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
    }
}
