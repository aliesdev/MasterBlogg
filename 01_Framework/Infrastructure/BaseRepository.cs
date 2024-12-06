using System.Linq.Expressions;
using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_Framework.Infrastructure;

public class BaseRepository<TKey, T>: IRepository<TKey, T> where T : DomainBase<TKey>
{
    private readonly DbContext context;

    public BaseRepository(DbContext context)
    {
        this.context = context;
    }

    public void Create(T entity)
    {
        context.Add<T>(entity);
    }

    public T Get(TKey id)
    {
        return context.Find<T>(id);
    }

    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public bool Exists(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().Any(expression);
    }
}