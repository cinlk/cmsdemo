using System;
using news.Models;
using OrchardCore.ContentManagement;
using YesSql.Indexes;
namespace news.Indexes 
{
    public class NewsModelIndex : MapIndex
    {

        // 关联的contentitem id
        public string ContentItemId { get; set; }

        // 标题
        public string Title { get; set; }

        // 作者
        public string Authtor { get; set; }

        // 封面图片 url
        public string CoverImgUrl { get; set; }

        // 创建日期时间
        public DateTime? CreatedAt { get; set; }

    }



    public class NewsModelIndexProvider : IndexProvider<ContentItem>
    {


        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<NewsModelIndex>().Map(item =>
            {
                var n = item.As<NewsModel>();
                if (n == null)
                {
                    return null;
                }

                return new NewsModelIndex
                {
                    ContentItemId = item.ContentItemId,

                    Title = n.Title,
                    Authtor = n.Authtor,
                    CoverImgUrl = n.CoverImgUrl,
                    CreatedAt = n.CreatedAt,
                };
            });
               
            }
        }
    }


