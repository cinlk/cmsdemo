using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using portalNews.Controllers;
using portalNews.Models;


namespace portalNews.Navigation
{
    public class NewsModuleMenu : INavigationProvider
    {

        private readonly IStringLocalizer T;

        public NewsModuleMenu(IStringLocalizer<NewsModuleMenu> sl)
        {
            T = sl;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            // add in subitem

            //var t =  menus.Where(item => item.Text == "orchard module").Single();

            builder.Add(T["界面内容模板"], "6",(menu =>
            
                 menu.LinkToFirstChild(true)
                 .AddClass("Persons").Id("Persons")
                 .Add(T["newsPage"], subitem =>
                 subitem.LinkToFirstChild(true)
                 .Add(T["newsList"], thirdLevel =>
                 thirdLevel.Action(nameof(AdminController.NewsList),
                 "Admin", new { area = $"{nameof(portalNews)}" }).LocalNav())
                ))
            );

          


            return Task.CompletedTask;


        }
    }
}
