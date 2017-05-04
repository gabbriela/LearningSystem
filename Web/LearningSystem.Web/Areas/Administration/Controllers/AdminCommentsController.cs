using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Common;
using LearningSystem.Data;
using LearningSystem.Models;

namespace LearningSystem.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class AdminCommentsController : AdminController
    {
        public AdminCommentsController(ILearningSystemData data) 
            : base(data)
        {
        }
        
        public ActionResult Index()
        {
            var comments = this.Data.Comments
                .All()
                .Include(c => c.Author)
                .Include(c => c.StudyMaterial);

            return View(comments.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = this.Data.Comments.GetById(id);

            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var comment = this.Data.Comments.GetById(id);

            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                this.Data.Context.Entry(comment).State = EntityState.Modified;
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: Administration/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = this.Data.Comments.GetById(id);

            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.Data.Comments.Delete(id);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
