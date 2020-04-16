using System;
using OrchardCore.Media.Fields;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace articleModule.Models
{
    public class ArticleModel : ContentPart
    {

        public string title { get; set; }
        public TextField  authorName { get; set; }
        public string coverImage { get; set; }
        public HtmlField  textBody { get; set; }

    }
}
