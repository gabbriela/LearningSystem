using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.ViewModels.Comments;

namespace LearningSystem.Services.Infrastructure.Contracts
{
    public interface ICommentService
    {
        ICollection<CommentViewModel> GetAllCommentsByPRojectId(int projectId);
    }
}
