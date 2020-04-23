using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.ContentManagement.Display;
using OrchardCore.DisplayManagement;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;

using portalJobs.Models;
using YesSql;


namespace portalJobs.Controllers
{
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

        public async Task<ActionResult> PublishedJobList()
        {
            var models = await _session.Query<ContentItem, ContentItemIndex>()
            .Where(index => index.ContentType == nameof(JobModel) && index.Latest == true)
            .OrderBy(index => index.CreatedUtc).ListAsync();


            return View("JobList", await GetShapes(models));
        }



        private async Task<IEnumerable<IShape>> GetShapes(IEnumerable<ContentItem> articles) =>
            await Task.WhenAll(articles.Select(async article =>
               await _contentItemDisplay.BuildDisplayAsync(article, this, "SummaryAdmin")));
    }
}
