using MB.Application.Contracts.ArticleCategory;

namespace MB.Application.Contracts.Article;

public interface IArticleApplication
{
    List<ArticleViewModel> GetList();
    void Create(CreateArticle command);
}