using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView  Article { get; set; }
        private readonly IArticleQuery articleQuery;
        private readonly ICommentApplication commentApplication;

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            this.articleQuery = articleQuery;
            this.commentApplication = commentApplication;
        }

        public void OnGet(int id)
        {
            Article = articleQuery.GetArticleDetails(id);
        }

        public RedirectToPageResult OnPost(AddComment command)
        {
            commentApplication.AddComment(command);
            return RedirectToPage("./ArticleDetails" ,new {id = command.ArticleId});
        }
    }
}
