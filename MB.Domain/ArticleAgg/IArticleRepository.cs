using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg;

public interface IArticleRepository
{
    List<ArticleViewModel> GetAll();
    Article Get(int id);
    void CreateAndSave(Article article);
    bool Exists(string title);
    void Save();
}