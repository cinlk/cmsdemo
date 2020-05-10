using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Navigation;
using YesSql.Indexes;


using portalEnglish.Indexes;
using portalEnglish.Models;
using portalEnglish.Migrations;
using portalEnglish.Drivers;
using portalEnglish.Navigation;

namespace portalEnglish
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            // company part
            services.AddContentPart<EnglishCompanyModel>();
            services.AddScoped<IDataMigration, CompanyMigration>();
            services.AddSingleton<IIndexProvider, ViraiEnglishCompanyIndexProvider>();
            services.AddScoped<IContentPartDisplayDriver, CompanyDriver>();

            //services.AddScoped<IContentPartDisplayDriver, compan>

            // contact part
            services.AddContentPart<EnglishContactModel>();
            services.AddScoped<IDataMigration, ContactMigration>();
            services.AddSingleton<IIndexProvider, VirtaiEnglishContactIndexProvider>();
            services.AddScoped<IContentPartDisplayDriver, ContactDriver>();


            services.AddScoped<INavigationProvider, PortalEnglishMenu>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "portalEnglish",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}