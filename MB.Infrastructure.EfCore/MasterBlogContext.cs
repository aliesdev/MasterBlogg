using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore;

public class MasterBlogContext : DbContext
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }

    public MasterBlogContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
        base.OnModelCreating(modelBuilder);
    }
}