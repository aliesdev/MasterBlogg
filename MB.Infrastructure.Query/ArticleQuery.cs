using System.Globalization;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBlogContext context;

    public ArticleQuery(MasterBlogContext context)
    {
        this.context = context;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView()
        {
            Id = x.Id,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = x.ShortDescription,
            Title = x.Title,
            Image = x.Image
        }).ToList();
    }

    public ArticleQueryView GetArticleDetails(int id)
    {
        return context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView()
        {
            Id = x.Id,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = x.ShortDescription,
            Title = x.Title,
            Image = x.Image
        }).FirstOrDefault(x => x.Id == id);
    }
}