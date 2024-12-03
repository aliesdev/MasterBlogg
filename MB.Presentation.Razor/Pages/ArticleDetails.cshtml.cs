using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }
        private readonly IArticleQuery articleQuery;

        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            this.articleQuery = articleQuery;
        }

        public void OnGet(int id)
        {
            Article = articleQuery.GetArticleDetails(id);
        }
    }
}
