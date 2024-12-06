using System.Globalization;
using MB.Domain.CommentAgg;
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
        return context.Articles
            .Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Select(x => new ArticleQueryView()
            {
                Id = x.Id,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Image = x.Image,
                CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),

            }).ToList();
    }



    public ArticleQueryView GetArticleDetails(int id)
    {
        return context.Articles
            .Include(x => x.ArticleCategory)
            .Select(x => new ArticleQueryView()
            {
                Id = x.Id,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Image = x.Image,
                CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),
                CommentList = MapComments(x.Comments.Where(z => z.Status == Statuses.Confirmed))
            }).FirstOrDefault(x => x.Id == id);
    }

    private static List<CommentQueryView> MapComments(IEnumerable<Comment> xComments)
    {
        return xComments
            .Select(comment => new CommentQueryView
            {
                Name = comment.Name,
                Message = comment.Message,
                CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture)
            })
            .ToList();
    }

}