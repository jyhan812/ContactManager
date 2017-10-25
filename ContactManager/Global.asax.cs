using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Hangfire;
using Hangfire.SqlServer;
using System;
using ContactManager.Helpers;
using NCrontab.Advanced;
using NCrontab.Advanced.Enumerations;

namespace ContactManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private BackgroundJobServer _backgroundJobServer;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration
                .UseSqlServerStorage(@"Data Source = USGCYL508; Initial Catalog = Hangfire; Integrated Security = SSPI;");
            
            _backgroundJobServer = new BackgroundJobServer();

            //string schedule = CrontabSchedule.Parse("30 * * * * *", CronStringFormat.WithSeconds).ToString();

            RecurringJob.AddOrUpdate(() => ScheduledJob(), Cron.MinuteInterval(1));

        }

        public void ScheduledJob()
        {
            UpdateDisplayName job = new UpdateDisplayName();

            job.updateDisplayName();

        }

        protected void Application_End(object sender, EventArgs e)
        {
            _backgroundJobServer.Dispose();
        }
    }

}
