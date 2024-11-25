using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = articleCategoryApplication.List();
        }

        public RedirectToPageResult OnPostRemove(int id)
        {
            articleCategoryApplication.Remove(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostRestore(int id)
        {
            articleCategoryApplication.Activate(id);
            return RedirectToPage("./List");
        }
    }
}