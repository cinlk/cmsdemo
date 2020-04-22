using System;
using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;

namespace portalIntroduce.Models
{
    public class CompanyIntroduceModel : ContentPart
    {
        public string title { get; set; }

        public string coverImg { get; set; }

        public TextField content { get; set; }
    }
}
