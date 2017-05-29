using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Turismall.Models;
using Turismall.Services;

namespace Turismall.Controllers
{
    public class NotaController : Controller
    {
        private readonly INotaService _service;
        
        public NotaController(INotaService service)
        {
            _service = service;
        }

        // GET: Nota
        public IActionResult Index(int? idViaje, string nombreViaje)
        {
            var notas = _service.GetByViaje(idViaje);
            if (notas == null)
            {
                return NotFound();
            }
            ViewBag.viaje = nombreViaje;
            ViewBag.idViaje = idViaje;
            return View(notas);
        }

        // GET: Nota/Details/5
        public IActionResult Details(int? id)
        {
            var nota = _service.GetById(id);
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
                Fecha = DateTime.Today
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
                _service.UploadFile(nota, HttpContext.Request.Form.Files);
                _service.Create(nota);
                _service.Save();
                _service.UpdateFechas(nota);
                return RedirectToAction("Index", new { idViaje = nota.ViajeID });
            }
            return View(nota);
        }

        // GET: Nota/Edit/5
        public IActionResult Edit(int? id)
        {
            var nota = _service.GetById(id);
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
        public IActionResult Edit(Nota nota)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.UploadFile(nota, HttpContext.Request.Form.Files);
                    _service.Update(nota);
                    _service.Save();
                    _service.UpdateFechas(nota);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction("Index", new { idViaje = nota.ViajeID });
            }
            return View(nota);
        }

    }
}
