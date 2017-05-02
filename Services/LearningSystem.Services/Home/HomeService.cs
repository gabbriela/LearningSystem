namespace LearningSystem.Services.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Services.Base;
    using LearningSystem.Services.Infrastructure.Contracts;
    using LearningSystem.ViewModels.Home;

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