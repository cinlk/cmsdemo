using System;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

using portalIntroduce.ViewModels;
using portalIntroduce.Models;

namespace portalIntroduce.Drivers

{
    public class TeamIntroduceDriver :  ContentPartDisplayDriver<TeamIntroduceModel>
    {


        public override IDisplayResult Display(TeamIntroduceModel part)
        {
            return View(nameof(TeamIntroduceModel), part);
        }


        public override IDisplayResult Edit(TeamIntroduceModel part)
        {
            return Initialize<TeamIntroduceViewModel>($"{nameof(TeamIntroduceModel)}_Edit", model =>
            {
                model.avatarImg = part.avatarImg;
                model.teamIntroduceModel = part;

            }).Location("Content:2");
        }

        public override async Task<IDisplayResult> UpdateAsync(TeamIntroduceModel part, IUpdateModel updater)
        {

            var vm = new TeamIntroduceViewModel();

            await updater.TryUpdateModelAsync(vm, Prefix);

            part.avatarImg = vm.avatarImg;

            return Edit(part);
        }
    }
}
