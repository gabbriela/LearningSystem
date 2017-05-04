using System.Web.Mvc;
using LearningSystem.Data;

namespace LearningSystem.Web.Controllers
{
    [RoutePrefix("certificate")]
    public class CertificationController : BaseController
    {
        public CertificationController(ILearningSystemData data)
            :base(data)
        {
        }
        
        [Route("info")]
        public ActionResult Info()
        {
            return View();
        }

        
    }
}