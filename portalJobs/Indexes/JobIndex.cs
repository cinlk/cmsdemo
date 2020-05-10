using System;
using OrchardCore.ContentManagement;
using portalJobs.Models;
using YesSql.Indexes;

namespace portalJobs.Indexes
{
    public class JobIndex : MapIndex
    {

        public string contentItemId { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public int count { get; set; }

        // 枚举
        public JobLocation location { get; set; }

        public DateTime publishedTime { get; set; }

        public string contactEmail { get; set; }

        public string contactPhone { get; set; }

        // 添加 有效字段 TODO


    }


    public class JobIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<JobIndex>()
                .Map(item =>
                {
                    var model = item.As<JobModel>();

                    if (model == null)
                    {
                        return null;
                    }

                    return new JobIndex
                    {

                        contentItemId = item.ContentItemId,
                        name = model.name,
                        type = model.type,
                        count = model.count,
                        location = model.location,
                        publishedTime = model.publishedTime,
                        contactEmail = model.contactEmail,
                        contactPhone = model.contactPhone
                    };

                });
        }
    }
}
