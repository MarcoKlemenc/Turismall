using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Turismall.Models;

namespace Turismall.Data
{
    public class NotaRepository : INotaRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public NotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Nota> GetNotasByViaje(int? ViajeId)
        {
            if (ViajeId == null)
            {
                return null;
            }
            return _context.Nota.Where(x => x.ViajeID == ViajeId).OrderByDescending(x => x.Fecha);
        }

        public Nota GetNotaByID(int? NotaId)
        {
            if (NotaId == null)
            {
                return null;
            }
            return _context.Nota.SingleOrDefault(m => m.ID == NotaId);
        }

        public void InsertNota(Nota Nota)
        {
            _context.Nota.Add(Nota);
        }

        public void DeleteNota(int NotaID)
        {
            Nota Nota = _context.Nota.Find(NotaID);
            _context.Nota.Remove(Nota);
        }

        public void UpdateNota(Nota Nota)
        {
            _context.Entry(Nota).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
