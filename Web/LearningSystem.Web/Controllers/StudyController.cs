using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningSystem.Web.Controllers
{
    public class StudyController : BaseController
    {
        // GET: Study
        public ActionResult Sections()
        {
            var sections = this.db.Sections.ToList();

            return View(sections);
        }

        public ActionResult Section(int id)
        {
            var sections = this.db.Sections.ToList();

            return null; //View(sections);
        }

        public ActionResult Edit(int id)
        {
            var sections = this.db.Sections.ToList();

            return null; //View(sections);
        }


        
    }
}