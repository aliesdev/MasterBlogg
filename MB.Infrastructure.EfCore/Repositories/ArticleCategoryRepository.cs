using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleCategoryRepository : IArticleCategoryRepository
{
    private readonly MasterBlogContext context;

    public ArticleCategoryRepository(MasterBlogContext context)
    {
        this.context = context;
    }

    public List<ArticleCategory> GetAll()
    {
        return context.ArticleCategories.ToList();
    }

    public ArticleCategory Get(int id)
    {
        return context.ArticleCategories.FirstOrDefault(x => x.Id == id);
    }

    public void Add(ArticleCategory category)
    {
        context.ArticleCategories.Add(category);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public void Remove(int id)
    {
        var articleCategory = context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        articleCategory.Remove();
        context.SaveChanges();
    }

    public void Restore(int id)
    {
        var articleCategory = context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        articleCategory.Activate();
        context.SaveChanges();
    }

    public bool Exists(string title)
    {
        return context.ArticleCategories.Any(x => x.Title.ToLower() == title.ToLower());
    }
}