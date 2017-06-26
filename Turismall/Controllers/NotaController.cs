using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Turismall.Models;
using Turismall.Services;

namespace Turismall.Controllers
{
    [Authorize]
    public class NotaController : Controller
    {
        private readonly INotaService _service;
        
        private List<SelectListItem> ObtenerDestinos()
        {
            var list = new List<SelectListItem>();
            foreach (Destino d in _service.GetDestinos())
            {
                list.Add(new SelectListItem() { Text = d.Nombre, Value = d.ID.ToString() });
            }
            return list;
        }

        public NotaController(INotaService service)
        {
            _service = service;
        }

        // GET: Nota
        public IActionResult Index(int? idViaje)
        {
            var notas = _service.GetByViaje(idViaje);
            if (notas == null)
            {
                return NotFound();
            }
            else if (notas.Count > 0)
            {
                List<String> destinos = new List<String>();
                foreach (Nota n in notas)
                {
                    String destino = _service.GetNombreDestino(n.DestinoID);
                    if (destinos.Count == 0 || destinos[destinos.Count - 1] != destino)
                    destinos.Add(destino);
                }
                String medio = "";
                for (int i = destinos.Count - 2; i >= 1; i--)
                {
                    medio += destinos[i] + "|";
                }
                
                String src = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyBDCXyJWzSE8dLkMKnMHawLr_u_RDHZ57w&origin=";
                src += destinos[destinos.Count - 1];
                src += "&destination=";
                src += destinos[0];
                if (medio.Length > 0)
                {
                    src += "&waypoints=";
                    src += medio.Remove(medio.Length - 1);
                }
                ViewBag.src = src;
            }
            ViewBag.viaje = _service.GetViajeName(idViaje);
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
            ViewBag.Destino = _service.GetNombreDestino(nota.DestinoID);
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
            ViewBag.Destinos = ObtenerDestinos();
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
            ViewBag.Destinos = ObtenerDestinos();
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
            ViewBag.Destinos = ObtenerDestinos();
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
            ViewBag.Destinos = ObtenerDestinos();
            return View(nota);
        }

        // GET: Nota/Edit/5
        public IActionResult Photo(int? id)
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
        public IActionResult Photo(Nota nota)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.UploadFile(nota, HttpContext.Request.Form.Files);
                    _service.Update(nota);
                    _service.Save();
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
