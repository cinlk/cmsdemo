using System;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.Data.Migration;

using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;

using portalJobs.Models;
using portalJobs.Indexes;

namespace portalJobs.Migrarions
{
    public class JobMigration : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefineManager;


        public JobMigration(IContentDefinitionManager cm)
        {
            _contentDefineManager = cm;
        }


        public int Create()
        {
            _contentDefineManager.AlterPartDefinition(nameof(JobModel), part => {

                part.WithField(nameof(JobModel.requiredList), conf =>
                {
                    conf.OfType(nameof(TextField))
                    .WithDisplayName("company introduce content")
                    .WithEditor("TextArea")
                    .WithSettings(new TextFieldSettings
                    {
                        Required = true
                    });
                });

                part.WithField(nameof(JobModel.responsileList), conf =>
                {
                   conf.OfType(nameof(TextField))
                  .WithDisplayName("company introduce content")
                  .WithEditor("TextArea")
                  .WithSettings(new TextFieldSettings
                  {
                      Required = true
                  });


                });
            });

            _contentDefineManager.AlterTypeDefinition(nameof(JobModel), builder => {
                builder.Creatable()
                .Listable().Draftable()
                .WithPart(nameof(JobModel));

            });

            SchemaBuilder.CreateMapIndexTable(nameof(JobIndex), table => {

                table.Column<string>(nameof(JobIndex.contentItemId))
                .Column<string>(nameof(JobIndex.name))
                .Column<string>(nameof(JobIndex.type))
                .Column<string>(nameof(JobModel.location))
                .Column<DateTime>(nameof(JobIndex.publishedTime))
                .Column<int>(nameof(JobIndex.count))
                .Column<string>(nameof(JobIndex.contactEmail))
                .Column<string>(nameof(JobIndex.contactPhone));

            });

            return 1;
        }
    }
}
