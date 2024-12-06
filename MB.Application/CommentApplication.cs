using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application;

public class CommentApplication : ICommentApplication
{
    private readonly ICommentRepository commentRepository;
    private readonly IUnitOfWork unitOfWork;

    public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
    {
        this.commentRepository = commentRepository;
        this.unitOfWork = unitOfWork;
    }

    public List<CommentViewModel> GetComments()
    {
        return commentRepository.GetList();
    }

    public void AddComment(AddComment command)
    {
        unitOfWork.BeginTran();
        commentRepository
            .Create(new Comment(command.Name, command.Email, command.Message, command.ArticleId));
        unitOfWork.CommitTran();
    }

    public void Confirm(int id)
    {
        unitOfWork.BeginTran();
        var comment = commentRepository.Get(id);
        comment.Confirm();
        unitOfWork.CommitTran();
    }

    public void Cancel(int id)
    {
        unitOfWork.BeginTran();
        var comment = commentRepository.Get(id);
        comment.Cancel();
        unitOfWork.CommitTran();
    }
}