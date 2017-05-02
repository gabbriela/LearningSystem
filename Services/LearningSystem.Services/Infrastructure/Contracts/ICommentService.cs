namespace LearningSystem.Services.Infrastructure.Contracts
{
    using System.Collections.Generic;
    using ViewModels.Comments;

    public interface ICommentService
    {
        ICollection<CommentViewModel> GetAllCommentsByPRojectId(int projectId);
    }
}
