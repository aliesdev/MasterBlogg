using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_Framework.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly MasterBlogContext context;

    public UnitOfWork(MasterBlogContext context)
    {
        this.context = context;
    }

    public void BeginTran()
    {
        context.Database.BeginTransaction();
    }

    public void CommitTran()
    {
        context.SaveChanges();
        context.Database.CommitTransaction();
    }

    public void Rollback()
    {
        context.Database.RollbackTransaction();
    }
}