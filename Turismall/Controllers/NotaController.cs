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
        private readonly INotaRepository _repository;
        private IHostingEnvironment _env;

        public NotaController(INotaRepository repository, IHostingEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        // GET: Nota
        public IActionResult Index(int? idViaje, string nombreViaje)
        {
            var notas = _repository.GetNotasByViaje(idViaje);
            {
                return NotFound();
            }
            ViewBag.viaje = _context.Viaje.SingleOrDefault(x => x.ID == idViaje).Nombre;
            ViewBag.idViaje = idViaje;
            return View(notas);
        }

        // GET: Nota/Details/5
        public IActionResult Details(int? id)
        {
            var nota = _repository.GetNotaByID(id);
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
                _repository.InsertNota(nota);
                _repository.Save();
                return RedirectToAction("Index", new { idViaje = nota.ViajeID });
            }
            return View(nota);
        }

        // GET: Nota/Edit/5
        public IActionResult Edit(int? id)
        {
            var nota = _repository.GetNotaByID(id);
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
                    _repository.UpdateNota(nota);
                    _repository.Save();
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
            var nota = _repository.GetNotaByID(id);
            if (nota == null)
            {
                return NotFound();
            }
            return View(nota);
        }

        private bool NotaExists(int id)
        {
            return _repository.GetNotaByID(id) != null;
        }
    }
}
