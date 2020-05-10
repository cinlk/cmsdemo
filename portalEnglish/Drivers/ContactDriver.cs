using System.Threading.Tasks;

using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

using Microsoft.Extensions.Logging;
using portalEnglish.ViewModels;
using portalEnglish.Models;

namespace portalEnglish.Drivers
{
    public class ContactDriver : ContentPartDisplayDriver<EnglishContactModel>
    {

        private readonly ILogger _logger;
        public ContactDriver(ILogger<ContactDriver> logger)
        {
            _logger = logger;
        }

        public override IDisplayResult Display(EnglishContactModel part)
        {
            _logger.LogInformation(" ------>english contact model show");
            return View(nameof(EnglishContactModel), part);
        }


        public override IDisplayResult Edit(EnglishContactModel part)
        {

            _logger.LogInformation(" ------>english contact model edit show");

            return Initialize<ContactViewModel>($"{nameof(EnglishContactModel)}_Edit",
                 model =>
                 {
                     model.Address = part.Address;
                     model.BackgroundImgUrl = part.BackgroundImgUrl;
                     model.Email = part.Email;
                     model.Number = part.Number;
                     model.EnglishContactModel = part;
                 })
            .Location("Content:2");
        }


        public override async Task<IDisplayResult> UpdateAsync(EnglishContactModel part, IUpdateModel updater)
        {

            var vm = new ContactViewModel();

            await updater.TryUpdateModelAsync(vm, Prefix);

            part.BackgroundImgUrl = vm.BackgroundImgUrl;
            part.Address = vm.Address;
            part.Email = vm.Email;
            part.Number = vm.Number;

            return Edit(part);
        }

    }
}
