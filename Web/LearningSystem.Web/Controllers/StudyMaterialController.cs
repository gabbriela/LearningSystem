using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningSystem.Web.Controllers
{
    public class StudyMaterialController : Controller
    {
        // GET: StudyMaterial
        public ActionResult Index()
        {
            return this.View();
        }

        //public ActionResult Create(StudyMaterialInputModel model)
        //{
        //    if (model != null && this.ModelState.IsValid)
        //    {
        //        var section = this.db.Sections.FirstOrDefault();

        //        var material = new StudyMaterial()
        //        {
        //            AuthorId = this.User.Identity.GetUserId(),
        //            Title = model.Title,
        //            Content = model.Content,
        //            Section = section
        //        };

        //        db.StudyMaterials.Add(material);
        //        db.SaveChanges();
        //        this.AddNotification("Material created.", NotificationType.INFO);
        //        return this.RedirectToAction("My");
        //    }

        //    return View(model);
        //}

        //Edit study material

        //list study materials from given section
    }
}