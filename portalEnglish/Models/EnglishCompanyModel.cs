using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace portalEnglish.Models
{
    public class EnglishCompanyModel : ContentPart
    {

        public string Title { get; set; }

        public string SubTitle { get; set; }


        public string CompanyBackgroundImgUrl { get; set; }

        public string CompanyProfileImgUrl { get; set; }


        public  TextField CompanyDetail { get; set; }

    }
}
