using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Services.Base;
using LearningSystem.Services.Infrastructure.Contracts;
using LearningSystem.ViewModels.Comments;
using LearningSystem.ViewModels.Study;

namespace LearningSystem.Services.Study
{
    public class StudyService : BaseService, IStudyService
    {
        public StudyService(ILearningSystemData data) 
            : base(data)
        {

        }

        public StudyMaterialViewModel GetStudyMaterialViewModel(int id)
        {
            var studyMaterialById = this.Data
                .StudyMaterials
                .All()
                .Where(m => m.Id == id)
                .OrderBy(m => m.Id)
                .Project()
                .To<StudyMaterialViewModel>()
                .FirstOrDefault();

            return studyMaterialById;
        }

        public IEnumerable<AllMaterialsViewModel> GetAllStudyMaterials()
        {
            var studyMaterialById = this.Data
                .StudyMaterials
                .All()
                .Project()
                .To<AllMaterialsViewModel>()
                .ToList();

            return studyMaterialById;
        }

        public ICollection<CommentViewModel> GetAllCommentsByPRojectId(int projectId)
        {
            return this.Data
                .Comments
                .All()
                .Where(c => c.StudyMaterialId == projectId)
                .Project()
                .To<CommentViewModel>()
                .ToList();
        }

        public IEnumerable<AllSectionsViewModel> GetAllSections()
        {
            var studyMaterialById = this.Data
                .Sections
                .All()
                .Project()
                .To<AllSectionsViewModel>()
                .ToList();

            return studyMaterialById;
        }
        
        public IEnumerable<StudyMaterialViewModel> GetStudyMaterialsBySection(int id)
        {
            var studyMaterialBySection = this.Data
                .StudyMaterials
                .All()
                .Where(m => m.SectionId == id)
                .Project()
                .To<StudyMaterialViewModel>()
                .ToList();

            return studyMaterialBySection;
        }
    }
}