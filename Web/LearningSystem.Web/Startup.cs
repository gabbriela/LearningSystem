using Microsoft.Owin;

[assembly: OwinStartup(typeof(LearningSystem.Web.Startup))]

namespace LearningSystem.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
