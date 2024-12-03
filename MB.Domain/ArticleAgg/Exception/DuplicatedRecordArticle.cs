namespace MB.Domain.ArticleAgg.Exception;

public class DuplicatedRecordArticle: System.Exception
{
    public DuplicatedRecordArticle()
    {
    }

    public DuplicatedRecordArticle(string? message) : base(message)
    {
    }
}