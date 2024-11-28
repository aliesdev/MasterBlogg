namespace MB.Domain.ArticleAgg.Services;

public interface IArticleValidatorService
{
    void IsRecordExists(string title);
}