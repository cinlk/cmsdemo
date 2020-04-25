using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using portalIntroduce.Controllers;

namespace portalIntroduce.Navigation
{
    public class PortalIntroduceMenu : INavigationProvider
    {

        private readonly IStringLocalizer T;

        public PortalIntroduceMenu(IStringLocalizer<PortalIntroduceMenu> localize)
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
                .Add(T["introducePage"], subItem =>
                {
                    subItem.LinkToFirstChild(true)
                    .Add(T["company"], thirdLevel =>
                    {
                        thirdLevel.Action(nameof(AdminController.PublishedCompanyIntroduce),
                            "Admin", new { area = $"{nameof(portalIntroduce)}" }).LocalNav();
                    }).Add(T["team"], thirdLevel =>
                    {
                        thirdLevel.Action(nameof(AdminController.PublishedTeamIntroduce),
                            "Admin", new { area = $"{nameof(portalIntroduce)}" }).LocalNav();
                    });
                });

            });


            return Task.CompletedTask;

        }
    }
}
