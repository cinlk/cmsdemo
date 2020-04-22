using System;
using OrchardCore.ContentManagement;
using portalIntroduce.Models;
using YesSql.Indexes;

namespace portalIntroduce.Indexes
{
    public class TeamIntroduceIndex : MapIndex
    {

        // document  id ??
        public string contentItemId { get; set; }

        public string avatarImg { get; set; }
        
    }


    public class TeamIntroduceIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {

            context.For<TeamIntroduceIndex>()
                .Map(item =>
                {
                    var model = item.As<TeamIntroduceModel>();
                    if (model == null)
                    {
                        return null;
                    }

                    return new TeamIntroduceIndex
                    {
                        contentItemId = item.ContentItemId,
                        avatarImg = model.avatarImg,
                    };

                });
        }
    }
}
