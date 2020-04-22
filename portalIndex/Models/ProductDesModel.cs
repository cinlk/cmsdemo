using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;
namespace portalIndex.Models
{
    public class ProductDesModel : ContentPart
    {

        public string icon { get; set; }

        public TextField des { get; set; }

    }
}
