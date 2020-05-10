using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;
namespace portalIndex.Models
{
    public class ProductDesModel : ContentPart
    {

        // 区分中英文 类型
        public LaguangeType Languange { get; set; } 

        public string icon { get; set; }

        public TextField des { get; set; }

    }

    public enum LaguangeType
    {
        Chinese,
        English

    }
}