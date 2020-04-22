using System;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

using portalIntroduce.Models;
using portalIntroduce.ViewModels;

namespace portalIntroduce.Drivers
{
    public class CompanyIntroduceDriver : ContentPartDisplayDriver<CompanyIntroduceModel>
    {

        public override IDisplayResult Display(CompanyIntroduceModel part)
        {
            return View(nameof(CompanyIntroduceModel), part);
        }

        public override IDisplayResult Edit(CompanyIntroduceModel part)
        {
            return Initialize<CompanyIntroduceViewModel>($"{nameof(CompanyIntroduceModel)}_Edit", model =>
            {
                model.coverImg = part.coverImg;
                model.title = part.title;
                model.companyIntroduceModel = part;

            }).Location("Content:1");
        }

        public override async Task<IDisplayResult> UpdateAsync(CompanyIntroduceModel part, IUpdateModel updater)
        {
            var vm = new CompanyIntroduceViewModel();
            await updater.TryUpdateModelAsync(vm, Prefix);

            part.coverImg = vm.coverImg;
            part.title = vm.title;

            return Edit(part);

        }

    }
}
