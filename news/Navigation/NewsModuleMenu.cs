using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using news.Controllers;
using news.Models;


namespace news.Navigation
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
            
            builder.Add(T["orchard modules"], "6", menu =>
               menu.LinkToFirstChild(true)
                 .Add(T["news"], subitem =>
                 subitem.LinkToFirstChild(true)
                 .Add(T["news-part1"], thirdLevel =>
                 thirdLevel.Action(nameof(HomeController.Index),
                 "Home", new { area = $"{nameof(NewsModel)}" }).LocalNav())
                 .Add(T["news-part2"], thirdLevel =>
                 thirdLevel.Action(nameof(HomeController.Index),
                 "Home", new { area = $"{nameof(NewsModel)}" }).LocalNav())
                )
            );


            return Task.CompletedTask;


        }
    }
}
