using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Turismall.Models;

namespace Turismall.Data
{
    public class ViajeRepository : IViajeRepository, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ViajeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Viaje> GetViajes()
        {
            return _context.Viaje.ToList();
        }

        public IEnumerable<Viaje> GetViajesByUser(String userId)
        {
            return _context.Viaje.Where(x => x.Usuario == userId);
        }

        public Viaje GetViajeByID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return _context.Viaje.Find(id);
        }

        public void InsertViaje(Viaje Viaje)
        {
            _context.Viaje.Add(Viaje);
        }

        public void DeleteViaje(int ViajeID)
        {
            Viaje Viaje = _context.Viaje.Find(ViajeID);
            _context.Viaje.Remove(Viaje);
        }

        public void UpdateViaje(Viaje Viaje)
        {
            _context.Entry(Viaje).State = EntityState.Modified;
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
