using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Data;

namespace LearningSystem.Web.Controllers
{
    public class QuestionsController : BaseController
    {
        public QuestionsController(ILearningSystemData data) : base(data)
        {
            
        }

        // GET: Questions
        public ActionResult Index()
        {
            return this.View();
        }
    }
}