namespace LearningSystem.Services.Infrastructure.Contracts
{
    using System.Collections.Generic;
    using LearningSystem.ViewModels.Home;

    public interface IHomeService
    {
        IList<MostVotedMaterialsViewModel> GetIndexViewModel(int count);
    }
}
