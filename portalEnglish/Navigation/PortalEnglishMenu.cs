using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using portalEnglish.Controllers;


namespace portalEnglish.Navigation
{
    public class PortalEnglishMenu : INavigationProvider
    {

        private readonly IStringLocalizer T;


        public PortalEnglishMenu(IStringLocalizer<PortalEnglishMenu> localize)
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
                //menu.AddClass("").Id("")
                menu.LinkToFirstChild(true)
                .Add(T["englishPage"], subItem =>
                {
                    subItem.LinkToFirstChild(true)
                    .Add(T["company"], thirdLevel =>
                    {
                        thirdLevel.Action(nameof(AdminController.PublishedCompanyIntroduce),
                            "Admin", new { area = $"{nameof(portalEnglish)}" }).LocalNav();
                    }).Add(T["contact"], thirdLevel =>
                    {
                        thirdLevel.Action(nameof(AdminController.PublishedContact),
                            "Admin", new { area = $"{nameof(portalEnglish)}" }).LocalNav();
                    });
                });

            });



            return Task.CompletedTask;

        }
    }
}
