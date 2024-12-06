using _01_Framework.Infrastructure;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository articleCategoryRepository;
    private readonly IArticleCategoryValidatorService articleCategoryValidatorService;
    private readonly IUnitOfWork unitOfWork;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,
        IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
    {
        this.articleCategoryRepository = articleCategoryRepository;
        this.articleCategoryValidatorService = articleCategoryValidatorService;
        this.unitOfWork = unitOfWork;
    }

    public List<ArticleCategoryViewModel> List()
    {
        var articleCategories = articleCategoryRepository.GetAll();

        return articleCategories.Select(articleCategory => new ArticleCategoryViewModel
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
                CreationDate = articleCategory.CreationDate.ToString(),
                IsDeleted = articleCategory.IsDeleted,
            })
            .OrderByDescending(x => x.Id).ToList();
    }

    public void Create(CreateArticleCategory command)
    {
        unitOfWork.BeginTran();
        var articleCategory = new ArticleCategory(command.Title, articleCategoryValidatorService);
        articleCategoryRepository.Create(articleCategory);
        unitOfWork.CommitTran();
    }

    public void Rename(RenameArticleCategory command)
    {
        unitOfWork.BeginTran();
        var articleCategory = articleCategoryRepository.Get(command.Id);
        articleCategory.Rename(command.Title);
        unitOfWork.CommitTran();
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
        unitOfWork.BeginTran();
        var articleCategory = articleCategoryRepository.Get(id);
        articleCategory.Remove();
        unitOfWork.CommitTran();
    }

    public void Activate(int id)
    {
        unitOfWork.BeginTran();
        var articleCategory = articleCategoryRepository.Get(id);
        articleCategory.Activate();
        unitOfWork.CommitTran();
    }
}