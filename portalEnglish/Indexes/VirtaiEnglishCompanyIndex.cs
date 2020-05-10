using System;
using portalEnglish.Models;
using OrchardCore.ContentManagement;
using YesSql.Indexes;
namespace portalEnglish.Indexes
{
    public class VirtaiEnglishCompanyIndex : MapIndex
    {

        public string ContentItemId { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string CompanyBackgroundImgUrl { get; set; }

        public string CompanyProfileImgUrl { get; set; }
    

    }


    public class ViraiEnglishCompanyIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<VirtaiEnglishCompanyIndex>().Map(item =>
            {
                var model = item.As<EnglishCompanyModel>();
                if (model == null)
                {
                    return null;
                }

                return new VirtaiEnglishCompanyIndex
                {
                    ContentItemId = item.ContentItemId,
                    Title = model.Title,
                    SubTitle = model.SubTitle,
                    CompanyProfileImgUrl = model.CompanyProfileImgUrl,
                    CompanyBackgroundImgUrl = model.CompanyBackgroundImgUrl,
                };


            });
        }
    }
}
