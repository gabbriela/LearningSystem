namespace LearningSystem.Services.Infrastructure.Contracts
{
    using System.Collections.Generic;
    using LearningSystem.ViewModels.Comments;
    using LearningSystem.ViewModels.Study;

    public interface IStudyService
    {
        StudyMaterialViewModel GetStudyMaterialViewModel(int id);

        IEnumerable<AllMaterialsViewModel> GetAllStudyMaterials();

        ICollection<CommentViewModel> GetAllCommentsByPRojectId(int projectId);

        IEnumerable<AllSectionsViewModel> GetAllSections();

        IEnumerable<StudyMaterialViewModel> GetStudyMaterialsBySection(int id);
    }
}