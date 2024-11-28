using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.Razor.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication articleApplication;
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public List<SelectListItem> Categories;
        [BindProperty] public EditArticle Article { get; set; }

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleApplication = articleApplication;
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(int id)
        {
            Article = articleApplication.Get(id);
            Categories = articleCategoryApplication.List().Select(x => new SelectListItem(x.Title, x.Id.ToString()))
                .ToList();
        }

        public RedirectToPageResult OnPost()
        {
            articleApplication.Edit(Article);
            return RedirectToPage("./List");
        }
    }
}