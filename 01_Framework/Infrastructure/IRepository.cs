﻿using System.Linq.Expressions;
using _01_Framework.Domain;

namespace _01_Framework.Infrastructure;

public interface IRepository<in TKey, T> where T : DomainBase<TKey>
{
    void Create(T entity);
    T Get(TKey id);
    List<T> GetAll();
    bool Exists(Expression<Func<T, bool>> expression);
}