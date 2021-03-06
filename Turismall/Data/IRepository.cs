﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Turismall.Data
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> GetMany(Expression<Func<T, bool>> predicate);
        List<T> GetSorted(Expression<Func<T, bool>> predicate, Expression<Func<T, IComparable>> order);
        T GetOne(Expression<Func<T, bool>> predicate);
        void Insert(T t);
        void Update(T t);
        void Save();
    }
}
