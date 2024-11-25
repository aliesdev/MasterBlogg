using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleCategoryAgg.Services;

public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
{
    private readonly IArticleCategoryRepository articleCategoryRepository;

    public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
    {
        this.articleCategoryRepository = articleCategoryRepository;
    }

    public void IsRecordExists(string title)
    {
        if (articleCategoryRepository.Exists(title))
        {
            throw new DuplicatedRecordException("already exists category! this is personal exception.");
        }
    }
}