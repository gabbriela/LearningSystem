using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Web.Infrastructure.Services.Contracts;
using LearningSystem.Web.ViewModels.Study;

namespace LearningSystem.Web.Controllers
{
    public class StudyMaterialController : BaseController
    {
        private IStudyService studyService;

        public StudyMaterialController(ILearningSystemData data, IStudyService studyService) : base(data)
        {
            this.studyService = studyService;
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

        public ActionResult Details(int id)
        {
            var studyMaterialById = studyService.GetIndexViewModel(id);

            if (studyMaterialById == null)
            {
                throw new HttpException(404, "Study material not found.");
            }

            return this.View(studyMaterialById); 
        }

        //Edit study material

        //list study materials from given section
    }
}