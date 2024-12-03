using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleAgg;

public class Article
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string ShortDescription { get; private set; }
    public string Image { get; private set; }
    public string Content { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreationDate { get; private set; }
    public int ArticleCategoryId { get; private set; }
    public ArticleCategory ArticleCategory { get; private set; }

    public Article()
    {
    }

    public Article(string title, string shortDescription, string image, string content, int articleCategoryId, IArticleValidatorService articleValidatorService)
    {
        articleValidatorService.IsRecordExists(title);
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategoryId = articleCategoryId;
        IsDeleted = false;
        CreationDate = DateTime.Now;
    }

    public void Edit(string title, string shortDescription, string image, string content, int articleCategoryI)
    {
       
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategoryId = articleCategoryI;
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