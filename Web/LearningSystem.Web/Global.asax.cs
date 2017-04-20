﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LearningSystem.Data;
using LearningSystem.Data.Migrations;

namespace LearningSystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<LearningSystemDbContext, DbMigrationsConfig>());

            ViewEngineConfig.ViewEngineReset();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
