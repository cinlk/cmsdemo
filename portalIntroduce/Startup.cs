using System;
using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.DisplayManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Navigation;
using OrchardCore.Modules;

using portalIntroduce.Models;
using portalIntroduce.ViewModels;
using portalIntroduce.Indexes;
using portalIntroduce.Drivers;
using portalIntroduce.Migrations;
using portalIntroduce.Navigation;
using YesSql.Indexes;

namespace portalIntroduce
{
    public class Startup : StartupBase
    {

        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<CompanyIntroduceViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<TeamIntroduceViewModel>();

        }

        public override void ConfigureServices(IServiceCollection services)
        {


            // menu
            services.AddScoped<INavigationProvider, PortalIntroduceMenu>();

            // companyIntroduce

            services.AddContentPart<CompanyIntroduceModel>();
            services.AddScoped<IDataMigration, CompanyIntroduceMigration>();
            services.AddScoped<IContentPartDisplayDriver, CompanyIntroduceDriver>();
            services.AddSingleton<IIndexProvider, CompanyIntroduceIndexProvider>();

            // TeamIntroduce

            services.AddContentPart<TeamIntroduceModel>();
            services.AddScoped<IDataMigration, TeamIntroduceMigration>();
            services.AddScoped<IContentPartDisplayDriver, TeamIntroduceDriver>();
            services.AddSingleton<IIndexProvider, TeamIntroduceIndexProvider>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}