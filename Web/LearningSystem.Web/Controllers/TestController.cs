namespace LearningSystem.Web.Controllers
{
    using System.Web.Mvc;
    using LearningSystem.Data;
    using LearningSystem.Services.Infrastructure.Contracts;

    [RoutePrefix("test")]
    public class TestController : BaseController
    {
        private IStudyService studyService;

        public TestController(ILearningSystemData data, IStudyService studyService) 
            : base(data)
        {
            this.studyService = studyService;
        }

        // GET: Test
        public ActionResult Index()
        {
            var allSections = studyService.GetAllSections();

            return View(allSections);
        }

        [Route("statistic")]
        public ActionResult Statistic()
        {
            return View();
        }
    }
}