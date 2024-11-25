using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreationDate { get; private set; }

    public ArticleCategory()
    {
    }

    public ArticleCategory(string title, IArticleCategoryValidatorService articleCategoryValidator)
    {
        articleCategoryValidator.IsRecordExists(title);
        Title = title;
        IsDeleted = false;
        CreationDate = DateTime.Now;
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