using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Data;

namespace LearningSystem.Web.Controllers
{
    public class StudyMaterialController : BaseController
    {
        public StudyMaterialController(ILearningSystemData data) : base(data)
        {

        }

        // GET: StudyMaterial
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult AddMaterial()
        {
            return this.View();
        }

        //Edit study material

        //list study materials from given section
    }
}