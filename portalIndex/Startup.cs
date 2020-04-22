using System;
using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Navigation;
using portalIndex.ViewModels;
using portalIndex.Indexes;
using portalIndex.Migrations;
using portalIndex.Drivers;
using portalIndex.Models;
using portalIndex.Navigation;
using YesSql.Indexes;

namespace portalIndex
{
    public class Startup : StartupBase
    {

        static Startup()
        {
            // ???
            TemplateContext.GlobalMemberAccessStrategy.Register<ProductDesViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<ClientExampleViewModel>();
        }


        public override void ConfigureServices(IServiceCollection services)
        {

            // add menu
            services.AddScoped<INavigationProvider, ModuleMenu>();

            // add product
            services.AddContentPart<ProductDesModel>();
            services.AddScoped<IDataMigration, ProductDesMigration>();
            services.AddScoped<IContentPartDisplayDriver, ProductDesDriver>();
            services.AddSingleton<IIndexProvider, ProductDesIndexProvider>();


            //add clientExample
            services.AddContentPart<ClientExampleModel>();
            services.AddScoped<IDataMigration, ClientExampleMigration>();
            services.AddScoped<IContentPartDisplayDriver, ClientExampleDriver>();
            services.AddSingleton<IIndexProvider, ClientExampleIndexProvider>();


        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}