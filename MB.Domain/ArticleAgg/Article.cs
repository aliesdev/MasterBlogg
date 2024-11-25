using MB.Domain.ArticleCategoryAgg;

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

    public Article(string title, string shortDescription, string image, string content, ArticleCategory articleCategory)
    {
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategory = articleCategory;
        IsDeleted = false;
        CreationDate = DateTime.Now;
    }
}