using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Web.Infrastructure.Services.Base;
using LearningSystem.Web.Infrastructure.Services.Contracts;
using LearningSystem.Web.ViewModels.Study;

namespace LearningSystem.Web.Infrastructure.Services.Study
{
    public class StudyService : BaseService, IStudyService
    {
        public StudyService(ILearningSystemData data) 
            : base(data)
        {

        }

        public StudyMaterialViewModel GetIndexViewModel(int id)
        {
            var studyMaterialById = this.Data
                .StudyMaterials
                .All()
                .Where(m => m.Id == id)
                .Project()
                .To<StudyMaterialViewModel>()
                .FirstOrDefault();

            return studyMaterialById;
        }
    }
}