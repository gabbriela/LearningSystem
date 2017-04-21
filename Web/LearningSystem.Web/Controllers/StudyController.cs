using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Data;

namespace LearningSystem.Web.Controllers
{
    public class StudyController : BaseController
    {
        public StudyController(ILearningSystemData data) : base(data)
        {

        }

        // GET: Study
        public ActionResult Sections()
        {
            
            return View();
        }

        public ActionResult Section(int id)
        {
           
            return null; //View(sections);
        }

        public ActionResult Edit(int id)
        {
            
            return null; //View(sections);
        }


        
    }
}