using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application;

public class ArticleApplication : IArticleApplication
{
    private readonly IArticleRepository articleRepository;

    public ArticleApplication(IArticleRepository articleRepository)
    {
        this.articleRepository = articleRepository;
    }

    public List<ArticleViewModel> GetList()
    {
        return articleRepository.GetAll();
    }

    public void Create(CreateArticle command)
    {
        articleRepository.CreateAndSave(
            new Article(
                command.Title,
                command.ShortDescription,
                command.Image,
                command.Content,
                command.ArticleCategoryId)
        );
    }

    public void Edit(EditArticle command)
    {
        var article = articleRepository.Get(command.Id);
        article.Edit(
            command.Title,
            command.ShortDescription,
            command.Image,
            command.Content,
            command.ArticleCategoryId
        );
        articleRepository.Save();
        
    }

    public EditArticle Get(int id)
    {
        var article = articleRepository.Get(id);
        return new EditArticle()
        {
            Id = article.Id,
            Title = article.Title,
            ArticleCategoryId = article.ArticleCategoryId,
            Content = article.Content,
            Image = article.Image,
            ShortDescription = article.ShortDescription
        };
    }

    public void Remove(int id)
    {
        var article = articleRepository.Get(id);
        article.Remove();
        articleRepository.Save();
    }

    public void Activate(int id)
    {
        var article = articleRepository.Get(id);
        article.Activate();
        articleRepository.Save();
    }
}