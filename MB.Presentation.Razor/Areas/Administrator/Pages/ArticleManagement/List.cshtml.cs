using MB.Application;
using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Areas.Administrator.Pages.ArticleManagement
{
    
    public class ListModel : PageModel
    {
        private readonly IArticleApplication articleApplication;
        public List<ArticleViewModel> Articles { get; set; }

        public ListModel(IArticleApplication articleApplication)
        {
            this.articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = articleApplication.GetList();
        }
        public RedirectToPageResult OnPostRemove(int id)
        {
            articleApplication.Remove(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostRestore(int id)
        {
            articleApplication.Activate(id);
            return RedirectToPage("./List");
        }
    }
}
