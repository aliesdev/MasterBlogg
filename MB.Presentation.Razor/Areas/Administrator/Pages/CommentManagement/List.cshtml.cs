using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments;
        private readonly ICommentApplication commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            this.commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = commentApplication.GetComments();
        }

        public RedirectToPageResult OnPostConfirm(int id)
        {
            commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostCancel(int id)
        {
            commentApplication.Cancel(id);
            return RedirectToPage("./List");
        }
    }
}
