using System;
using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;

namespace portalEnglish.Models
{
    public class EnglishContactModel : ContentPart
    {

        public string Address { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public string BackgroundImgUrl { get; set; }

        // test add virtual field
        public BooleanField bools { get; set; }
    }
}
