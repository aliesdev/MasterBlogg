using System.Globalization;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleRepository: IArticleRepository
{
    private readonly MasterBlogContext context;

    public ArticleRepository(MasterBlogContext context)
    {
        this.context = context;
    }

    public List<ArticleViewModel> GetAll()
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

    public Article Get(int id)
    {
        return context.Articles.FirstOrDefault(x => x.Id == id);
    }

    public void CreateAndSave(Article article)
    {
        context.Articles.Add(article);
        Save();
    }

    public void Save()
    {
        context.SaveChanges();
    }
}