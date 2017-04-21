using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Data;
using LearningSystem.Web.ViewModels.Home;
using AutoMapper.QueryableExtensions;
using LearningSystem.Web.Infrastructure.Services.Contracts;

namespace LearningSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IHomeService homeService;

        public HomeController(ILearningSystemData data, IHomeService homeService)
            :base(data)
        {
            this.homeService = homeService;
        }

        public ActionResult Index()
        {
            return View(homeService.GetIndexViewModel(4));
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Error()
        {
            return this.View();
        }
    }
}