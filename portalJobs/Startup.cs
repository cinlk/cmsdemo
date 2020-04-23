using System;
using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Navigation;
using OrchardCore.ContentManagement.Display.ContentDisplay;


using portalJobs.Models;
using portalJobs.ViewModels;
using portalJobs.Indexes;
using portalJobs.Drivers;
using portalJobs.Migrarions;
using portalJobs.Navigation;


using YesSql.Indexes;

namespace portalJobs
{
    public class Startup : StartupBase
    {

        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<JobViewModel>();

        }

        public override void ConfigureServices(IServiceCollection services)
        {

            // menu
            services.AddScoped<INavigationProvider, PortalJobsMenu>();
            // joblist

            services.AddContentPart<JobModel>();
            services.AddScoped<IDataMigration, JobMigration>();
            services.AddScoped<IContentPartDisplayDriver, JobDriver>();
            services.AddSingleton<IIndexProvider, JobIndexProvider>();

        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}