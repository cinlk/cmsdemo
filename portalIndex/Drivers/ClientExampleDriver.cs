using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

using portalIndex.Models;
using portalIndex.ViewModels;

namespace portalIndex.Drivers
{
    public class ClientExampleDriver : ContentPartDisplayDriver<ClientExampleModel>
    {

        public override IDisplayResult Display(ClientExampleModel part)
        {
            return View(nameof(ClientExampleModel), part);
        }


        public override IDisplayResult Edit(ClientExampleModel part)
        {
            return Initialize<ClientExampleViewModel>($"{nameof(ClientExampleModel)}_Edit", model =>
            {
                model.coverImg = part.coverImg;
                model.createdTime = part.createdTime;
                model.title = part.title;
                model.clientExampleModel = part;

            }).Location("Content:3");


        }


        public override async Task<IDisplayResult> UpdateAsync(ClientExampleModel part, IUpdateModel updater)
        {
            var vm = new ClientExampleViewModel();

            await updater.TryUpdateModelAsync(vm, Prefix);


            part.coverImg = vm.coverImg;
            part.createdTime = vm.createdTime;
            part.title = vm.title;

            return Edit(part);
        }
    }
}
