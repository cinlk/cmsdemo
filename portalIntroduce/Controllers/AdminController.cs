using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.ContentManagement.Display;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.ContentManagement.Records;
using YesSql;
using portalIntroduce.Models;

namespace portalIntroduce.Controllers
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


        public async Task<ActionResult> PublishedCompanyIntroduce()
        {
            // 改成 选择一个 TODO
            var models = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(index => index.ContentType == nameof(CompanyIntroduceModel) && index.Latest == true)
                .OrderBy(index => index.CreatedUtc).ListAsync();


            return View("CompanyIntroduce", await GetShapes(models));
        }

        public async Task<ActionResult> PublishedTeamIntroduce()
        {

            var models = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(index => index.ContentType == nameof(TeamIntroduceModel) && index.Latest == true)
                .OrderBy(index => index.CreatedUtc).ListAsync();


            return View("TeamIntroduceList", await GetShapes(models));

        }

        private async Task<IEnumerable<IShape>> GetShapes(IEnumerable<ContentItem> articles) =>

           await Task.WhenAll(articles.Select(async article =>
               await _contentItemDisplay.BuildDisplayAsync(article, this, "SummaryAdmin")));
    }
}
