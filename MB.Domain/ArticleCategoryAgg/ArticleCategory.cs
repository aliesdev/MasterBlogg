using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory : DomainBase<int>
{
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public ICollection<Article> Articles { get; private set; }

    public ArticleCategory()
    {
    }

    public ArticleCategory(string title, IArticleCategoryValidatorService articleCategoryValidator)
    {
        articleCategoryValidator.IsRecordExists(title);
        Title = title;
        IsDeleted = false;
        Articles = new List<Article>();
    }

    public void Rename(string title)
    {
        Title = title; 
    }

    public void Remove()
    {
        IsDeleted = true;
    }

    public void Activate()
    {
        IsDeleted = false;
    }
}