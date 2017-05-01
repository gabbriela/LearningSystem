using System.Collections.Generic;
using LearningSystem.ViewModels.Home;

namespace LearningSystem.Services.Infrastructure.Contracts
{
    public interface IHomeService
    {
        IList<MostVotedMaterialsViewModel> GetIndexViewModel(int count);
    }
}
