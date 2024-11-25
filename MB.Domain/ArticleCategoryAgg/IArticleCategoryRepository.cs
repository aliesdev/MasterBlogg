using System.Runtime.InteropServices;

namespace MB.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository
{
    List<ArticleCategory> GetAll();
    ArticleCategory Get(int id);
    void Add(ArticleCategory category);
    void SaveChanges();
    void Remove(int id);
    void Restore(int  id);
    bool Exists(string title);
}