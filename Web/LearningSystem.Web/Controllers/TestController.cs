using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Data;
using LearningSystem.Services.Infrastructure.Contracts;

namespace LearningSystem.Web.Controllers
{
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
        
    }
}