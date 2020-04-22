using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;

namespace portalIntroduce.Models
{
    public class TeamIntroduceModel : ContentPart
    {

        public string avatarImg { get; set; }

        public HtmlField bio { get; set; }
    }
}
