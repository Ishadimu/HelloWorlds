using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HelloWorlds.Models;

namespace HelloWorlds
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // instead of create/migrate upon interaction,
            // automatically create/migrate upon deployment
            if (bool.Parse(ConfigurationManager.AppSettings["MigrateDatabaseToLatestVersion"]))
            {
                var appContext = new ApplicationDbContext();
                var initializeDomain = new CreateDatabaseIfNotExists<ApplicationDbContext>();
                var initializeMigrations = new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>(true);

                initializeDomain.InitializeDatabase(appContext);
                initializeMigrations.InitializeDatabase(appContext);
            }
        }
    }
}
