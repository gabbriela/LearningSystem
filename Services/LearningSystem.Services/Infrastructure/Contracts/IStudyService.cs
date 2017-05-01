using System.Collections.Generic;
using LearningSystem.ViewModels.Comments;
using LearningSystem.ViewModels.Study;

namespace LearningSystem.Services.Infrastructure.Contracts
{
    public interface IStudyService
    {
        StudyMaterialViewModel GetStudyMaterialViewModel(int id);

        IEnumerable<AllMaterialsViewModel> GetAllStudyMaterials();

        ICollection<CommentViewModel> GetAllCommentsByPRojectId(int projectId);

        IEnumerable<AllSectionsViewModel> GetAllSections();

        IEnumerable<StudyMaterialViewModel> GetStudyMaterialsBySection(int id);
    }
}