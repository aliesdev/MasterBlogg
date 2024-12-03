using MB.Domain.ArticleAgg.Exception;

namespace MB.Domain.ArticleAgg.Services;

public class ArticleValidatorService : IArticleValidatorService
{
    private readonly IArticleRepository articleRepository;

    public ArticleValidatorService(IArticleRepository articleRepository)
    {
        this.articleRepository = articleRepository;
    }

    public void IsRecordExists(string title)
    {
        if (articleRepository.Exists(title))
        {
            throw new DuplicatedRecordArticle("Article already exists");
        }
    }
}