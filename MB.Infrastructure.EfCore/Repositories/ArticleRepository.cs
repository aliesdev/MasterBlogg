using System.Globalization;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleRepository : BaseRepository<int, Article>, IArticleRepository
{
    private readonly MasterBlogContext context;

    public ArticleRepository(MasterBlogContext context) : base(context)
    {
        this.context = context;
    }

    public List<ArticleViewModel> GetList()
    {
        return context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel()
        {
            Id = x.Id,
            Title = x.Title,
            IsDeleted = x.IsDeleted,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).ToList();
    }
}