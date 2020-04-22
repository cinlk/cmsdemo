using System;
using OrchardCore.ContentManagement;
using portalIntroduce.Models;
using YesSql.Indexes;

namespace portalIntroduce.Indexes
{
    public class CompanyIntroduceIndex : MapIndex
    {
        // documentid  ???


        public string contentItemId { get; set; }

        public string title { get; set; }

        public string coverImg { get; set; }

    }


    public class CompanyIntroduceIndexProvider: IndexProvider<ContentItem>
    {

        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<CompanyIntroduceIndex>()
                 .Map(item =>
                 {

                     var model = item.As<CompanyIntroduceModel>();
                     if (model == null)
                     {
                         return null;
                     }
                     return new CompanyIntroduceIndex
                     {
                         contentItemId = item.ContentItemId,
                         title = model.title,
                         coverImg = model.coverImg,
                     };


                 });
        }
    }
}
