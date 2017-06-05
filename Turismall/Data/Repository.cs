using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Turismall.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetSorted(Expression<Func<T, bool>> predicate, Expression<Func<T, IComparable>> order)
        {
            return _context.Set<T>().Where(predicate).OrderByDescending(order).ToList();
        }

        public T GetOne(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public void Insert(T t)
        {
            _context.Set<T>().Add(t);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}
