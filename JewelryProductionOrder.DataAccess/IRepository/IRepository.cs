﻿using System.Linq.Expressions;

namespace Models.Repositories.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Model type
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

    }
}
