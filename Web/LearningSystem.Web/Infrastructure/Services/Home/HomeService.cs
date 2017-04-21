

using System.Collections.Generic;
using System.Linq;
using LearningSystem.Web.ViewModels.Home;
using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Web.Infrastructure.Services.Base;
using LearningSystem.Web.Infrastructure.Services.Contracts;

namespace LearningSystem.Web.Infrastructure.Services.Home
{
    public class HomeService : BaseService, IHomeService
    {
        public HomeService(ILearningSystemData data) 
            : base(data)
        {
            
        }

        public IList<MostVotedMaterialsViewModel> GetIndexViewModel(int count)
        {
            var indexViewModel = this.Data
               .StudyMaterials
               .All()
               .OrderByDescending(m => m.Votes.Count())
               .Take(count)
               .Project()
               .To<MostVotedMaterialsViewModel>()
               .ToList();

            return indexViewModel;
        }
    }
}