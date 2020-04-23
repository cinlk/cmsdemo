using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using portalJobs.Models;
using portalJobs.ViewModels;

namespace portalJobs.Drivers
{
    public class JobDriver : ContentPartDisplayDriver<JobModel>
    {

        public override IDisplayResult Display(JobModel part)
        {
            return View(nameof(JobModel), part);
        }

        public override IDisplayResult Edit(JobModel part)
        {
            return Initialize<JobViewModel>($"{nameof(JobModel)}_Edit", model =>
            {

                model.type = part.type;
                model.count = part.count;
                model.name = part.name;
                model.publishedTime = part.publishedTime;
                model.location = part.location;
                model.contactPhone = part.contactPhone;
                
                model.contactEmail = part.contactEmail;


                model.jobModel = part;
            }).Location("Content:1");
        }


        public override  async Task<IDisplayResult> UpdateAsync(JobModel part, IUpdateModel updater)
        {
            var vm = new JobViewModel();

            await updater.TryUpdateModelAsync(vm, Prefix);

            part.contactEmail = vm.contactEmail;
            part.contactPhone = vm.contactPhone;
            part.count = vm.count;
            part.location = vm.location;
            part.publishedTime = vm.publishedTime;
            part.name = vm.name;
            part.type = vm.type;

            return Edit(part);

        }
    }
}
