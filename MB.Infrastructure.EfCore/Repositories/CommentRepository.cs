using System.Globalization;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MB.Infrastructure.EfCore.Repositories;

public class CommentRepository : BaseRepository<int, Comment>, ICommentRepository
{
    private readonly MasterBlogContext context;

    public CommentRepository(MasterBlogContext context) : base(context)
    {
        this.context = context;
    }

    public List<CommentViewModel> GetList()
    {
        return context.Comments.Include(x => x.Article)
            .Select(x => new CommentViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Message = x.Message,
                Status = x.Status,
                Article = x.Article.Title,
                Email = x.Email
            }).ToList();
    }
}