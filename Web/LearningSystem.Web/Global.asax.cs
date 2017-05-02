namespace LearningSystem.Web
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using LearningSystem.Data;
    using LearningSystem.Data.Migrations;
    using LearningSystem.ViewModels;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<LearningSystemDbContext, DbMigrationsConfig>());
            AutoMapperConfig.Execute();

            ViewEngineConfig.ViewEngineReset();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
