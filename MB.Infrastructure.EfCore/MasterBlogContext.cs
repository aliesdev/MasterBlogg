using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore;

public class MasterBlogContext : DbContext
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public MasterBlogContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}