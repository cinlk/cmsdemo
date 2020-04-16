using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using articleModule.Models;
using articleModule.ViewModels;

namespace articleModule.Drivers
{
    public class ArticleDisplayDriver : ContentPartDisplayDriver<ArticleModel>
    {


        private readonly ILogger<ArticleDisplayDriver> _logger;


        public ArticleDisplayDriver(ILogger<ArticleDisplayDriver> logger)
        {
            _logger = logger;
        }

        public override IDisplayResult Display(ArticleModel part)
        {

            _logger.LogInformation(" ----> article Model  content display");
            return View(nameof(ArticleModel), part);
        }


        public override IDisplayResult Edit(ArticleModel part) =>



             Initialize<ArticleViewModel>($"{nameof(ArticleModel)}_Edit", model =>
             {

                 _logger.LogInformation(" ----> article Model  content Edit");

                 model.article = part;

                 model.CoverImage = part.coverImage;
                 model.Title = part.title;
                //model.authorName = part.authorName;
                //model.body = part.textBody;

             }).Location("Content:1");


        public override async Task<IDisplayResult> UpdateAsync(ArticleModel model, IUpdateModel updater)
        {
            var viewModel = new ArticleViewModel();

            // Now it's where the IUpdateModel interface is really used (remember we first used it in
            // DisplayManagementController?). With this you will be able to use the Controller's model binding helpers
            // here in the driver. The prefix property will be used to distinguish between similarly named input fields
            // when building the editor form (so e.g. two content parts composing a content item can have an input
            // field called "Name"). By default Orchard Core will use the content part name but if you have multiple
            // drivers with editors for a content part you need to override it in the driver.
            await updater.TryUpdateModelAsync(viewModel, Prefix);

            // Now you can do some validation if needed. One way to do it you can simply write your own validation here
            // or you can do it in the view model class.

            // Go and check the ViewModels/PersonPartViewModel to see how to do it and then come back here.

            // Finally map the view model to the content part. By default these changes won't be persisted if there was
            // a validation error. Otherwise these will be automatically stored in the database.
            model.coverImage = viewModel.CoverImage;
            model.title = viewModel.Title;
            //model.authorName = viewModel.authorName;
            //model.textBody = viewModel.body;

            return Edit(model);
        }


     


    }
}
