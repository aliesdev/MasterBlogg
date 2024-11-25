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
}