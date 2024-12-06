using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application;

public class ArticleApplication : IArticleApplication
{
    private readonly IArticleRepository articleRepository;
    private readonly IArticleValidatorService articleValidatorService;
    private readonly IUnitOfWork unitOfWork;

    public ArticleApplication(IArticleRepository articleRepository, IArticleValidatorService articleValidatorService, IUnitOfWork unitOfWork)
    {
        this.articleRepository = articleRepository;
        this.articleValidatorService = articleValidatorService;
        this.unitOfWork = unitOfWork;
    }

    public List<ArticleViewModel> GetList()
    {
        return articleRepository.GetList();
    }

    public void Create(CreateArticle command)
    {
        unitOfWork.BeginTran();
        articleRepository.Create(
            new Article(
                command.Title,
                command.ShortDescription,
                command.Image,
                command.Content,
                command.ArticleCategoryId ,
                articleValidatorService
                ));
        unitOfWork.CommitTran();
    }

    public void Edit(EditArticle command)
    {
        unitOfWork.BeginTran();
        var article = articleRepository.Get(command.Id);
        article.Edit(
            command.Title,
            command.ShortDescription,
            command.Image,
            command.Content,
            command.ArticleCategoryId
        );
        unitOfWork.CommitTran();

        
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
        unitOfWork.BeginTran();
        var article = articleRepository.Get(id);
        article.Remove();
        unitOfWork.CommitTran();
    
    }

    public void Activate(int id)
    {
        unitOfWork.BeginTran();
        var article = articleRepository.Get(id);
        article.Activate();
       unitOfWork.CommitTran();
    }
}