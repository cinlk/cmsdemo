using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using OrchardCore.ContentManagement.Display;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement;
using articleModule.Models;

using YesSql;

namespace articleModule.Controllers
{
    //  首页内容 模块列表显示控制
    public class AdminController : Controller, IUpdateModel
    {


        private readonly IContentItemDisplayManager _contentItemDisplay;
        private readonly ISession _session;
        private readonly IAuthenticationService _author;


        public AdminController(
            IContentItemDisplayManager cm,
            ISession session,
            IAuthenticationService author
            )
        {

            _contentItemDisplay = cm;
            _session = session;
            _author = author;
        }

        public ActionResult Index() => View();



        public async Task<ActionResult> PublishedArticleList()
        {
            // if (!await _author.AuthenticateAsync(User, ))

            var articles = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(index => index.ContentType == nameof(ArticleModel) && index.Latest == true)
                .OrderBy(index => index.CreatedUtc).ListAsync();


            return View("ArticleList", await GetShapes(articles));
                
        }

        private async Task<IEnumerable<IShape>> GetShapes(IEnumerable<ContentItem> articles) =>
           // Notice the "SummaryAdmin" display type which is a built in display type specifically for listing items
           // on the dashboard.
           await Task.WhenAll(articles.Select(async article =>
               await _contentItemDisplay.BuildDisplayAsync(article, this, "SummaryAdmin")));


    }
}
