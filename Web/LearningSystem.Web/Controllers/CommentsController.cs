using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LearningSystem.Data;
using LearningSystem.Models;
using LearningSystem.ViewModels.Comments;

namespace LearningSystem.Web.Controllers
{
    [RoutePrefix("comment")]
    public class CommentsController : BaseController
    {
        public CommentsController(ILearningSystemData data) 
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[NonAction]
        public ActionResult PostComment(PostCommentViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbComment = Mapper.Map<Comment>(model);
                dbComment.Author = this.UserProfile;
                var material = this.Data.StudyMaterials.GetById(model.MaterialId);
                if (material == null)
                {
                    throw new HttpException("404 material not found");
                }
                
                material.Comments.Add(dbComment);
                this.Data.SaveChanges();

                var viewModel = Mapper.Map<CommentViewModel>(dbComment);
                
                return PartialView("_CommentPartial", viewModel);
            }


            throw new HttpException(400, "Invalid comment");
        }
    }
}