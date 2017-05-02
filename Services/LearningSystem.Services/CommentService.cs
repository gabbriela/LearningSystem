namespace LearningSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Services.Base;
    using LearningSystem.Services.Infrastructure.Contracts;
    using LearningSystem.ViewModels.Comments;

    public class CommentService : BaseService, ICommentService
    {
        public CommentService(ILearningSystemData data) : base(data)
        {
        }

        public ICollection<CommentViewModel> GetAllCommentsByPRojectId(int projectId)
        {
            return this.Data
                .Comments
                .All()
                .Where(c => c.StudyMaterialId == projectId)
                .OrderByDescending(c => c.Id)
                .Project()
                .To<CommentViewModel>()
                .ToList();
        }
    }
}
