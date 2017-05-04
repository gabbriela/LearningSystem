using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Data;
using LearningSystem.Services.Infrastructure.Contracts;

namespace LearningSystem.Web.Controllers
{
    public class QuestionsController : BaseController
    {
        private IQuestionsService questionsService;
        private IStudyService studyService;
        public QuestionsController(ILearningSystemData data, IQuestionsService questionsService, IStudyService studyService) 
            : base(data)
        {
            this.questionsService = questionsService;
            this.studyService = studyService;
        }

        [Authorize]
        [Route("questions/section/{id:int}")]
        public ActionResult Section(int id)
        {
            var questionsBySection = questionsService.GetQuestionsBySection(id);

            return View(questionsBySection);
        }

        [Authorize]
        [Route("questions/sections")]
        public ActionResult Index()
        {
            var allSections = studyService.GetAllSections();

            return View(allSections);
        }
        
    }
}