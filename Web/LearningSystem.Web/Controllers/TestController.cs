using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Data;

namespace LearningSystem.Web.Controllers
{
    public class TestController : BaseController
    {

        public TestController(ILearningSystemData data) : base(data)
        {
            
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

       
    }
}