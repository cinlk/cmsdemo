using System;
using articleModule.Models;
using OrchardCore.ContentManagement;
using YesSql.Indexes;

namespace articleModule.Indexes
{
    public class ArticleContentIndex : MapIndex
    {

        //系统自加的documentid
        public int DocumentId { get; set; }

        public string ContentItemId { get; set; }

        public string Title { get; set; }

        public string? CoverImage { get; set; }


         
    }


    public class ArticleContentIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {

            context.For<ArticleContentIndex>().Map(contentItem =>
           {
               var m = contentItem.As<ArticleModel>();
               if (m == null)
               {
                   return null;
               }

               return new ArticleContentIndex
               {

                   
                   ContentItemId = contentItem.ContentItemId,
                   Title = m.title,
                   CoverImage = m.coverImage,
               };

           });
            //throw new NotImplementedException();
        }
    }
}
