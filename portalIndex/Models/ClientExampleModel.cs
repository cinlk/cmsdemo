using System;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace portalIndex.Models
{
    public class ClientExampleModel : ContentPart
    {

        public string coverImg { get; set; }

        public DateTime createdTime { get; set; }

        public string title { get; set; }

        public HtmlField content { get; set; }


    }
}
