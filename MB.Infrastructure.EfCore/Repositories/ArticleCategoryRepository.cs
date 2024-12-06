using _01_Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleCategoryRepository : BaseRepository<int, ArticleCategory>, IArticleCategoryRepository
{
    private readonly MasterBlogContext context;

    public ArticleCategoryRepository(MasterBlogContext context) : base(context)
    {
        this.context = context;
    }

}