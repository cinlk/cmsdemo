using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.DisplayManagement.ModelBinding;
using portalNews.Models;
using portalNews.ViewModels;

namespace portalNews.Drivers
{
    public class NewsModelPartDriver : ContentPartDisplayDriver<NewsModel>
    {


        private readonly ILogger<NewsModelPartDriver> _logger;


        public NewsModelPartDriver(ILogger<NewsModelPartDriver> logger)
        {
            _logger = logger;
        }


        public override IDisplayResult Display(NewsModel part)
        {

            _logger.LogInformation("---------------> {name}", nameof(NewsModel));

            //return View("demo", part);
            // 找不到 newsmodel type ？？
            return View(nameof(NewsModel), part);
              
        }


        public override IDisplayResult Edit(NewsModel part)
        {


            _logger.LogInformation("-----++++++++++++---------->");

            return Initialize<NewsViewModel>($"{nameof(NewsModel)}_Edit", model =>
            {

                
                model.News = part;
                model.Authtor = part.Authtor;
                model.CoverImgUrl = part.CoverImgUrl;
                model.CreatedAt = part.CreatedAt;
                model.Title = part.Title;
            }).Location("Content:1");
        }


        public override async Task<IDisplayResult> UpdateAsync(NewsModel part, IUpdateModel updater)
        {
            var vm = new NewsViewModel();

            await updater.TryUpdateModelAsync(vm, Prefix);

            part.Authtor = vm.Authtor;
            part.CreatedAt = vm.CreatedAt;
            part.Title = vm.Title;
            part.CoverImgUrl = vm.CoverImgUrl;

            return Edit(part);
        }

    }
}
