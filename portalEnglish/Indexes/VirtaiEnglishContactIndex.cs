using System;
using portalEnglish.Models;
using YesSql.Indexes;
using OrchardCore.ContentManagement;

namespace portalEnglish.Indexes
{
    public class VirtaiEnglishContactIndex : MapIndex
    {

        public string ContentItemId { get; set; }


        public string Address { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public string BackgroundImgUrl { get; set; }



    }


    public class VirtaiEnglishContactIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<VirtaiEnglishContactIndex>().Map(item =>
            {
                var model = item.As<EnglishContactModel>();
                if (model == null)
                {
                    return null;
                }

                return new VirtaiEnglishContactIndex
                {
                    ContentItemId = item.ContentItemId,
                    Address = model.Address,
                    Email = model.Email,
                    Number = model.Number,
                    BackgroundImgUrl = model.BackgroundImgUrl,
                };

            });
        }
    }
}
