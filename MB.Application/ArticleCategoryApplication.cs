using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application;

public class ArticleCategoryApplication: IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository articleCategoryRepository;
    private readonly IArticleCategoryValidatorService articleCategoryValidatorService;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
    {
        this.articleCategoryRepository = articleCategoryRepository;
        this.articleCategoryValidatorService = articleCategoryValidatorService;
    }

    public List<ArticleCategoryViewModel> List()
    {
        var articleCategories = articleCategoryRepository.GetAll();
        var result = new List<ArticleCategoryViewModel>();
        foreach (var articleCategory in articleCategories)
        {
            result.Add(new ArticleCategoryViewModel
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
                CreationDate = articleCategory.CreationDate.ToString(),
                IsDeleted = articleCategory.IsDeleted,
            });
        }
        return result;
    }

    public void Create(CreateArticleCategory command)
    {
        var articleCategory = new ArticleCategory(command.Title ,articleCategoryValidatorService);
        articleCategoryRepository.Add(articleCategory);
    }

    public void Rename(RenameArticleCategory command)
    {
        var articleCategory = articleCategoryRepository.Get(command.Id);
        articleCategory.Rename(command.Title); 
        articleCategoryRepository.SaveChanges();
    }

    public RenameArticleCategory Get(int id)
    {
        var articleCategory = articleCategoryRepository.Get(id);
        return new RenameArticleCategory()
        {
            Id = articleCategory.Id,
            Title = articleCategory.Title,
        };
    }

    public void Remove(int id)
    {
        var articleCategory = articleCategoryRepository.Get(id);
        articleCategory.Remove();
        articleCategoryRepository.SaveChanges();
    }

    public void Activate(int id)
    {
        var articleCategory = articleCategoryRepository.Get(id);
        articleCategory.Activate();
        articleCategoryRepository.SaveChanges();
    }
}