using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningSystem.Web.ViewModels.Study;

namespace LearningSystem.Web.Infrastructure.Services.Contracts
{
    public interface IStudyService
    {
        StudyMaterialViewModel GetIndexViewModel(int id);
    }
}