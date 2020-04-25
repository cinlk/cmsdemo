using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using portalJobs.Controllers;


namespace portalJobs.Navigation
{
    public class PortalJobsMenu : INavigationProvider
    {

        private readonly IStringLocalizer T;

        public PortalJobsMenu(IStringLocalizer<PortalJobsMenu> localize)
        {
            T = localize;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder.Add(T["portal modules"], "6", menu =>
            {
                
                menu.LinkToFirstChild(true)
                .Add(T["jobsPage"], subItem =>
                {
                    subItem.LinkToFirstChild(true)
                    .Add(T["jobList"], thirdLevel =>
                    {
                        thirdLevel.Action(nameof(AdminController.PublishedJobList),
                            "Admin", new { area = $"{nameof(portalJobs)}" }).LocalNav();
                    });
                });

            });


            return Task.CompletedTask;

        }
    }
}
