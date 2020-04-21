using System;
using OrchardCore.Navigation;

using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using articleModule.Controllers;

namespace articleModule.Navigation
{
    public class PortalModuleMenu : INavigationProvider
    {

        private readonly IStringLocalizer T;

        public PortalModuleMenu(IStringLocalizer<PortalModuleMenu> sl)
        {
            T = sl;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

           
            builder.Add(T["orchard modules"], "6", menu =>


               menu.AddClass("persons").Id("persons")
                .LinkToFirstChild(true)
                .Add(T["index-page"], subitem =>
                subitem.LinkToFirstChild(true)
                .Add(T["article1"], thirdLevel =>
                thirdLevel.Action(nameof(AdminController.Index),
                "Admin", new { area = $"{nameof(articleModule)}" }).LocalNav())
                .Add(T["articl2"], thirdLevel =>
                thirdLevel.Action(nameof(AdminController.PublishedArticleList),
                "Admin", new { area = $"{nameof(articleModule)}" }).LocalNav())
               )
           );
           



            return Task.CompletedTask;
        }
    }
}
