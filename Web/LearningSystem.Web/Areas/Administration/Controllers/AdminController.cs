using System.Web.Mvc;
using LearningSystem.Common;
using LearningSystem.Data;
using LearningSystem.Web.Controllers;

namespace LearningSystem.Web.Areas.Administration.Controllers
{

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        public AdminController(ILearningSystemData data) 
            : base(data)
        {
        }
    }
}