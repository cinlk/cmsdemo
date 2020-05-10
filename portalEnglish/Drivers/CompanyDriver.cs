using System.Threading.Tasks;

using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

using portalEnglish.ViewModels;
using portalEnglish.Models;

namespace portalEnglish.Drivers
{
    public class CompanyDriver : ContentPartDisplayDriver<EnglishCompanyModel>
    {

        public override IDisplayResult Display(EnglishCompanyModel part)
        {
            return View(nameof(EnglishCompanyModel), part);
        }


        public override IDisplayResult Edit(EnglishCompanyModel part)
        {
            return Initialize<CompanyViewModel>($"{nameof(EnglishCompanyModel)}_Edit",
                 model =>
                 {
                     model.CompanyBackgroundImgUrl = part.CompanyBackgroundImgUrl;
                     model.CompanyProfileImgUrl = part.CompanyProfileImgUrl;
                     model.SubTitle = part.SubTitle;
                     model.Title = part.Title;
                     model.EnglishCompanyModel = part;
                 })
            .Location("Content:1");
        }


        public override async Task<IDisplayResult> UpdateAsync(EnglishCompanyModel part, IUpdateModel updater)
        {

            var vm = new CompanyViewModel();

            await updater.TryUpdateModelAsync(vm, Prefix);

            part.CompanyProfileImgUrl = vm.CompanyProfileImgUrl;
            part.CompanyBackgroundImgUrl = vm.CompanyBackgroundImgUrl;
            part.SubTitle = vm.SubTitle;
            part.Title = vm.Title;

            return Edit(part);
        }
    }
}
