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
    public class AdminMaterialsController : Controller
    {
        private LearningSystemDbContext db = new LearningSystemDbContext();

        // GET: Administration/StudyMaterials
        public ActionResult Index()
        {
            var studyMaterials = db.StudyMaterials.Include(s => s.Author).Include(s => s.Section);
            return View(studyMaterials.ToList());
        }

        // GET: Administration/StudyMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyMaterial studyMaterial = db.StudyMaterials.Find(id);
            if (studyMaterial == null)
            {
                return HttpNotFound();
            }
            return View(studyMaterial);
        }

        // GET: Administration/StudyMaterials/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName");
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Title");
            return View();
        }

        // POST: Administration/StudyMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,PublishDate,Content,Description,Source,SectionId,AuthorId")] StudyMaterial studyMaterial)
        {
            if (ModelState.IsValid)
            {
                db.StudyMaterials.Add(studyMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", studyMaterial.AuthorId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Title", studyMaterial.SectionId);
            return View(studyMaterial);
        }

        // GET: Administration/StudyMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyMaterial studyMaterial = db.StudyMaterials.Find(id);
            if (studyMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", studyMaterial.AuthorId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Title", studyMaterial.SectionId);
            return View(studyMaterial);
        }

        // POST: Administration/StudyMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,PublishDate,Content,Description,Source,SectionId,AuthorId")] StudyMaterial studyMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FullName", studyMaterial.AuthorId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Title", studyMaterial.SectionId);
            return View(studyMaterial);
        }

        // GET: Administration/StudyMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyMaterial studyMaterial = db.StudyMaterials.Find(id);
            if (studyMaterial == null)
            {
                return HttpNotFound();
            }
            return View(studyMaterial);
        }

        // POST: Administration/StudyMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudyMaterial studyMaterial = db.StudyMaterials.Find(id);
            db.StudyMaterials.Remove(studyMaterial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
