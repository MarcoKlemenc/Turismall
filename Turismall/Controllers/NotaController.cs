using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Turismall.Data;
using Turismall.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Turismall.Controllers
{
    public class NotaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _env;

        public NotaController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Nota
        public IActionResult Index(int? idViaje)
        {
            if (idViaje == null)
            {
                return NotFound();
            }
            ViewBag.idViaje = idViaje;
            return View(_context.Nota.Where(x => x.ViajeID == idViaje));
        }

        // GET: Nota/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = _context.Nota
                .SingleOrDefault(m => m.ID == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Nota/Create
        public IActionResult Create(int idViaje)
        {
            Nota nota = new Nota
            {
                ViajeID = idViaje,
            };
            return View(nota);
        }

        // POST: Nota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Nota nota)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                var folder = Path.Combine("uploads", nota.ViajeID.ToString());
                var destination = Path.Combine(_env.WebRootPath, folder);
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        if (!Directory.Exists(destination))
                        {
                            Directory.CreateDirectory(destination);
                        }
                        var name = DateTime.Now.ToString("yyyyMMddHHmmssffff")+".jpg";
                        using (var fileStream = new FileStream(Path.Combine(destination, name), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            nota.Foto = Path.Combine(folder, name);
                        }
                    }
                }
                _context.Add(nota);
                _context.SaveChanges();
                return RedirectToAction("Index", new { idViaje = nota.ViajeID });
            }
            return View(nota);
        }

        // GET: Nota/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = _context.Nota.SingleOrDefault(m => m.ID == id);
            if (nota == null)
            {
                return NotFound();
            }
            return View(nota);
        }

        // POST: Nota/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Nota nota)
        {
            if (id != nota.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nota);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { idViaje = nota.ViajeID });
            }
            return View(nota);
        }

        // GET: Nota/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = _context.Nota
                .SingleOrDefault(m => m.ID == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var nota = _context.Nota.SingleOrDefault(m => m.ID == id);
            _context.Nota.Remove(nota);
            _context.SaveChanges();
            return RedirectToAction("Index", new { idViaje = nota.ViajeID });
        }

        private bool NotaExists(int id)
        {
            return _context.Nota.Any(e => e.ID == id);
        }
    }
}
