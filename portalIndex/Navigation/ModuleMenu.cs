using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using portalIndex.Controllers;

namespace portalIndex.Navigation
{
    public class ModuleMenu : INavigationProvider

    {

        private readonly IStringLocalizer T;

        public ModuleMenu(IStringLocalizer<ModuleMenu> localize)
        {
            T = localize;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder.Add(T["界面内容模板"], "6", menu =>
            {
                //icon class ??
                menu.AddClass("persons").Id("persons")
                .LinkToFirstChild(true)
                .Add(T["indexPage"], subitem =>
                {
                    subitem.LinkToFirstChild(true)
                    .Add(T["productDes"], thirdLevel =>
                    {
                        thirdLevel.Action(nameof(AdminController.PublishedProductDesList),
                            "Admin", new { area = $"{nameof(portalIndex)}" }).LocalNav();
                    }).Add(T["clientExample"], thirdLevel =>
                    {
                        thirdLevel.Action(nameof(AdminController.PublishedClientExampleList),
                            "Admin", new { area = $"{nameof(portalIndex)}" }).LocalNav();
                    });
                });

            });


            return Task.CompletedTask;
        }
    }
}
