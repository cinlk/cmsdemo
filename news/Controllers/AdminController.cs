using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement;
using news.Models;

using YesSql;

namespace news.Controllers
{
    public class AdminController : Controller, IUpdateModel
    {

        private readonly IContentItemDisplayManager _contentDisplay;
        private readonly ISession _session;


        public AdminController(IContentItemDisplayManager cm, ISession session)
        {

            _contentDisplay = cm;
            _session = session;

        }


        public ActionResult Index() => View();



        public async Task<ActionResult> NewsList()
        {
            var news = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(index => index.ContentType == nameof(NewsModel) && index.Latest == true)
                .OrderBy(index => index.CreatedUtc).ListAsync();

            return View("NewsList", await GetShapes(news));
        }


        private async Task<IEnumerable<IShape>> GetShapes(IEnumerable<ContentItem> news) =>

            await Task.WhenAll(news.Select(async (item) =>
                await _contentDisplay.BuildDisplayAsync(item, this, "SummaryAdmin")));
        
    }
}
