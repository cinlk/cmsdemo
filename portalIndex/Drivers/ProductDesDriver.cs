
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using portalIndex.ViewModels;
using portalIndex.Models;

namespace portalIndex.Drivers
{
    public class ProductDesDriver : ContentPartDisplayDriver<ProductDesModel>
    {


        public override IDisplayResult Display(ProductDesModel part)
        {
            return View(nameof(ProductDesModel), part);
        }


        public override IDisplayResult Edit(ProductDesModel part)
        {

            return Initialize<ProductDesViewModel>($"{nameof(ProductDesModel)}_Edit",
                 model =>
                 {
                     model.laguange = part.Languange;
                     model.icon = part.icon;
                     model.productDesModel = part;
                 })
            .Location("Content:1");
        }

        public override async Task<IDisplayResult> UpdateAsync(ProductDesModel part, IUpdateModel updater)
        {


            var vm = new ProductDesViewModel();

            await updater.TryUpdateModelAsync(vm, Prefix);

            part.Languange = vm.laguange;
            part.icon = vm.icon;

            return Edit(part);
        }



    }
}
