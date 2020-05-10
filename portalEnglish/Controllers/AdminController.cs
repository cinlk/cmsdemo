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
using portalEnglish.Models;
using YesSql;


namespace portalEnglish.Controllers
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
            var model = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(index => index.ContentType == nameof(EnglishCompanyModel) && index.Latest == true)
                .OrderByDescending(index => index.CreatedUtc).FirstOrDefaultAsync();


            if (model == null)
            {
                return View("Index");
            }

            var shape = await _contentItemDisplay.BuildDisplayAsync(model, this, "SummaryAdmin");
            return View("EnglishCompanyModelView", shape);
        }



        public async Task<ActionResult> PublishedContact()
        {
            // 改成 选择一个 TODO
            var model = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(index => index.ContentType == nameof(EnglishContactModel) && index.Latest == true)
                .OrderByDescending(index => index.CreatedUtc).FirstOrDefaultAsync();


            if (model == null)
            {
                return View("Index");
            }

            var shape = await _contentItemDisplay.BuildDisplayAsync(model, this, "SummaryAdmin");
            return View("EnglishContactModelView", shape);
        }




        private async Task<IEnumerable<IShape>> GetShapes(IEnumerable<ContentItem> articles) =>

           await Task.WhenAll(articles.Select(async article =>
               await _contentItemDisplay.BuildDisplayAsync(article, this, "SummaryAdmin")));

    }
}
