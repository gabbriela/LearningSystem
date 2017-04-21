using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LearningSystem.Data;
using LearningSystem.Models;
using Microsoft.AspNet.Identity;

namespace LearningSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ILearningSystemData Data { get; private set; }

        protected User UserProfile { get; private set; }

        public BaseController(ILearningSystemData data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile =
                this.Data.Users.All()
                    .Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name)
                    .FirstOrDefault();
            return base.BeginExecute(requestContext, callback, state);
        }

        public bool IsAdmin()
        {
            var currentUserId = this.User.Identity.GetUserId();
            return currentUserId != null && this.User.IsInRole("Administrator");
        }
    }
}