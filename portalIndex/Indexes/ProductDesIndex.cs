using System;
using OrchardCore.ContentManagement;
using portalIndex.Models;
using YesSql.Indexes;

namespace portalIndex.Indexes
{
    public class ProductDesIndex : MapIndex
    {

        // 系统自带documentid  TODO


        public string contentItemId { get; set; }

        public string icon { get; set; }
        

    }



    public class ProductDesIndexProvider : IndexProvider<ContentItem>
    {

        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<ProductDesIndex>().Map(item =>
            {
                var model = item.As<ProductDesModel>();
                if (model == null)
                {
                    return null;
                }
                return new ProductDesIndex
                {
                    contentItemId = item.ContentItemId,
                    icon = model.icon,
                };

            });
        }
    }
}
