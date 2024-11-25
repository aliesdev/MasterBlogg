using MB.Application.Contracts.ArticleCategory;
using NotImplementedException = System.NotImplementedException;

namespace MB.Domain.ArticleCategoryAgg.Services;

public interface IArticleCategoryValidatorService
{
    void IsRecordExists(string title);
}