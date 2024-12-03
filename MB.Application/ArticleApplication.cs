using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application;

public class ArticleApplication : IArticleApplication
{
    private readonly IArticleRepository articleRepository;
    private readonly IArticleValidatorService articleValidatorService;

    public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService)
    {
        this.articleRepository = articleRepository;
        this.articleValidatorService = articleValidatorService;
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
                command.ArticleCategoryId ,
                articleValidatorService
                ));
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