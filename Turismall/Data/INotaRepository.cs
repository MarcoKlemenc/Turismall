using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Turismall.Models;

namespace Turismall.Data
{
    public interface INotaRepository : IDisposable
    {
        List<Nota> GetSeveralByPredicate(Expression<Func<Nota, bool>> predicate);
        Nota GetByPredicate(Expression<Func<Nota, bool>> predicate);
        void Insert(Nota nota);
        void Update(Nota nota);
        void Save();
    }
}
