using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryView> Articles { get; set; }
        private readonly IArticleQuery articleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            this.articleQuery = articleQuery;
        }

        public void OnGet()
        {
            Articles = articleQuery.GetArticles();
        }
    }
}
