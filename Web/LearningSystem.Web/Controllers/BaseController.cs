using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Data;
using Microsoft.AspNet.Identity;

namespace LearningSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected LearningSystemDbContext db = new LearningSystemDbContext();

        public bool IsAdmin()
        {
            var currentUserId = this.User.Identity.GetUserId();
            return currentUserId != null && this.User.IsInRole("Administrator");
        }
    }
}