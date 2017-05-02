using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LearningSystem.Data;
using LearningSystem.Models;
using LearningSystem.Services.Infrastructure.Contracts;
using LearningSystem.ViewModels.Comments;
using LearningSystem.ViewModels.Study;

namespace LearningSystem.Web.Controllers
{
    public class StudyMaterialController : BaseController
    {
        private IStudyService studyService;
        private ICommentService commentService;

        public StudyMaterialController(ILearningSystemData data, IStudyService studyService, ICommentService commentService) 
            : base(data)
        {
            this.studyService = studyService;
            this.commentService = commentService;
        }

        // GET: StudyMaterial
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult AddMaterial()
        {
            var addMaterialViewModel = new AddMaterialViewModel()
            {
                Sections = this.Data.Sections
                .All()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Title
                })
            };

            return this.View(addMaterialViewModel); 
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMaterial(AddMaterialViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbMaterial = Mapper.Map<StudyMaterial>(model);

                dbMaterial.Author = this.UserProfile;

                if (model.UploadedImage != null)
                {
                    //Helper class in Infrastructure
                    using (var memory = new MemoryStream())
                    {
                        model.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        var fileExtension = model.UploadedImage.FileName.Split(new[] {'.'}).Last();

                        if (fileExtension != null && fileExtension != "jpeg")
                        {
                            fileExtension = "jpeg";
                        }

                        dbMaterial.Images = new List<Image>()
                        {
                            new Image()
                            {
                                Content = content,
                                FileExtension = fileExtension
                            }
                        };
                    }
                }

                this.Data.StudyMaterials.Add(dbMaterial);

                this.Data.SaveChanges();
                
                return RedirectToAction("AllMaterials", "StudyMaterial");
            }

            model.Sections = this.Data.Sections
                .All()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Title
                });

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var studyMaterialById = studyService.GetStudyMaterialViewModel(id);

            if (studyMaterialById == null)
            {
                 throw new HttpException(404, "Study material not found.");
            }
            
            var comments = commentService.GetAllCommentsByPRojectId(id);

            studyMaterialById.Comments = comments;

            return this.View(studyMaterialById); 
        }

        public ActionResult AllMaterials()
        {
            //sorted by votes
            var allStudyMaterials = studyService.GetAllStudyMaterials();

            return this.View(allStudyMaterials);
        }

        public ActionResult Image(int id)
        {
            var image = this.Data.Images.GetById(id);

            if (image == null)
            {
                throw new HttpException(404, "Image not found.");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }

        public ActionResult AllSections()
        {
            var allSections = studyService.GetAllSections();

            return View(allSections);
        }

        public ActionResult Section(int id)
        {
            var studyMaterialsBySection = studyService.GetStudyMaterialsBySection(id);

            return View(studyMaterialsBySection);
        }
    }
}