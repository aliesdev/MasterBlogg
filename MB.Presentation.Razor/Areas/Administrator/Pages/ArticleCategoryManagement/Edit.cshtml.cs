using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        [BindProperty] public RenameArticleCategory ArticleCategory { get; set; }

        private readonly IArticleCategoryApplication articleCategoryApplication;

        public void OnGet(int id)
        {
            ArticleCategory = articleCategoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            articleCategoryApplication.Rename(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}