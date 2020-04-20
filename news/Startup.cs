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

using news.Navigation;
using news.Models;
using news.Migrations;
using news.Indexes;
using news.Drivers;

namespace news
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            // news Part
            services.AddContentPart<NewsModel>();
            services.AddScoped<IDataMigration, NewsMigration>();
            services.AddScoped<IContentPartDisplayDriver, NewsModelPartDriver>();
            services.AddSingleton<IIndexProvider, NewsModelIndexProvider>();

            // dapper
            services.AddScoped<DbOperation>();

            // navigation menu
            services.AddScoped<INavigationProvider, NewsModuleMenu>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            //routes.MapAreaControllerRoute(
            //    name: "Home",
            //    areaName: "news",
            //    pattern: "Home/Index",
            //    defaults: new { controller = "Home", action = "Index" }
            //);
        }
    }
}