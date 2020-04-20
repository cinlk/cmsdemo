using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
//using OrchardCore.DisplayManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Navigation;
//using OrchardCore.Indexing;
using articleModule.Models;
using articleModule.Migrations;
using articleModule.Indexes;
using articleModule.Drivers;
using articleModule.Navigation;
using YesSql.Indexes;


namespace articleModule
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            
            // article Part
            services.AddContentPart<ArticleModel>();
            services.AddScoped<IDataMigration, ArticleContentMigrations>();
            services.AddScoped<IContentPartDisplayDriver, ArticleDisplayDriver>();
            services.AddSingleton<IIndexProvider, ArticleContentIndexProvider>();


            // register dapper
            services.AddSingleton<DbDapper>();


            // Admin Menu
            services.AddScoped<INavigationProvider, PortalModuleMenu>();

        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {

            //routes.MapControllerRoute(
            //    name: "articleModule",
            //    pattern: "{controller=Article}/{action=Index}/{id?}"
            //    );
        }
    }
}