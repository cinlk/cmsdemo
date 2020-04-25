using System;
using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;
namespace portalNews.Models
{
    public class NewsModel : ContentPart
    {
        // 标题
        public string Title { get; set; }

        // 作者
        public string Authtor { get; set; }

        // 封面图片 url
        public string CoverImgUrl { get; set; }

        // 创建日期时间
        public DateTime? CreatedAt { get; set; }


        /*
         * Fields
         */
        // 描述内容
        public TextField Description { get; set; }

        // 富文本描述(html)
        public HtmlField ContentBody { get; set; }


    }
}
