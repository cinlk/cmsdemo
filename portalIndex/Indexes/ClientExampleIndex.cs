using System;
using YesSql.Indexes;
using OrchardCore.ContentManagement;
using portalIndex.Models;

namespace portalIndex.Indexes
{
    public class ClientExampleIndex : MapIndex
    {

        public string contentItemId { get; set; }

        public string coverImg { get; set; }

        public DateTime createdTime { get; set; }

        public string title { get; set; }


    }


    public class ClientExampleIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<ClientExampleIndex>().Map( item => {
                var mode = item.As<ClientExampleModel>();
                if (mode == null)
                {
                    return null;
                }

                return new ClientExampleIndex
                {
                    contentItemId =  item.ContentItemId,
                    coverImg = mode.coverImg,
                    createdTime = mode.createdTime,
                    title = mode.title
                };

            });
        }
    }
}



