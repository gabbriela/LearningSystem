using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Web.ViewModels.Home;

namespace LearningSystem.Web.Infrastructure.Services.Contracts
{
    public interface IHomeService
    {
        IList<MostVotedMaterialsViewModel> GetIndexViewModel(int count);
    }
}
