using System.Web.Mvc;
using LearningSystem.Data;

namespace LearningSystem.Web.Controllers
{
    public class CertificationController : BaseController
    {
        public CertificationController(ILearningSystemData data)
            :base(data)
        {
            
        }

        // GET: Certification
        public ActionResult Index()
        {
            

            return View();
        }
        
    }
}