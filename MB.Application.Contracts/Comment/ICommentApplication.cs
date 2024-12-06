namespace MB.Application.Contracts.Comment;

public interface ICommentApplication
{
    List<CommentViewModel> GetComments();
    void AddComment(AddComment command);
    void Confirm(int  id);
    void Cancel(int id);

}