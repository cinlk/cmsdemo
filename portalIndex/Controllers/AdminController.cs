using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.ContentManagement.Display;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.ContentManagement.Records;
using portalIndex.Models;
using YesSql;


namespace portalIndex.Controllers
{
    public class AdminController : Controller, IUpdateModel
    {

        private readonly IContentItemDisplayManager _contentItemDisplay;

        private readonly ISession _session;

        private readonly IAuthenticationService _author;


        public AdminController(
            IContentItemDisplayManager cm,
            ISession session,
            IAuthenticationService author)
        {
            _contentItemDisplay = cm;
            _session = session;
            _author = author;
        }

        public ActionResult Index() => View();

        public async Task<ActionResult> PublishedProductDesList()
        {
            // if (!await _author.AuthenticateAsync(User, ))
            // 权限判断 TODO

            var models = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(index => index.ContentType == nameof(ProductDesModel) && index.Latest == true)
                .OrderBy(index => index.CreatedUtc).ListAsync();


            return View("ProductDesList", await GetShapes(models));

        }

        public async Task<ActionResult> PublishedClientExampleList()
        {
            var models = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(index => index.ContentType == nameof(ClientExampleModel) && index.Latest == true)
                .OrderBy(index => index.CreatedUtc).ListAsync();

            return View("ClientExampleList", await GetShapes(models));
        }

        private async Task<IEnumerable<IShape>> GetShapes(IEnumerable<ContentItem> articles) =>

           await Task.WhenAll(articles.Select(async article =>
               await _contentItemDisplay.BuildDisplayAsync(article, this, "SummaryAdmin")));
    }
    
}
