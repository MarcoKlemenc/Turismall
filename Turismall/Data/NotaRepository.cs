using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<Nota> GetSeveralByPredicate(Expression<Func<Nota, bool>> predicate)
        {
            return _context.Nota.Where(predicate.Compile()).OrderByDescending(x => x.Fecha);
        }

        public Nota GetByPredicate(Expression<Func<Nota, bool>> predicate)
        {
            return _context.Nota.FirstOrDefault(predicate.Compile());
        }

        public void Insert(Nota nota)
        {
            _context.Nota.Add(nota);
        }

        public void Update(Nota Nota)
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
