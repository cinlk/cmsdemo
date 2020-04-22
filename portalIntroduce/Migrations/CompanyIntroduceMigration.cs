using System;

using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;

using OrchardCore.Data.Migration;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;

using portalIntroduce.Models;
using portalIntroduce.Indexes;

namespace portalIntroduce.Migrations
{
    public class CompanyIntroduceMigration : DataMigration
    {

        private readonly IContentDefinitionManager _contentDefineManager;

        public CompanyIntroduceMigration(IContentDefinitionManager cm)
        {
            _contentDefineManager = cm;
        }

        public int Create()
        {

            _contentDefineManager.AlterPartDefinition(nameof(CompanyIntroduceModel), part =>
            {

                part.WithField(nameof(CompanyIntroduceModel.content), conf =>
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


            _contentDefineManager.AlterTypeDefinition(nameof(CompanyIntroduceModel), builder =>
            {
                builder.Creatable()
                .Listable()
                .WithPart(nameof(CompanyIntroduceModel));
            });

            SchemaBuilder.CreateMapIndexTable(nameof(CompanyIntroduceIndex), table =>
            {
                table.Column<string>(nameof(CompanyIntroduceIndex.title))
                .Column<string>(nameof(CompanyIntroduceIndex.coverImg))
                .Column<string>(nameof(CompanyIntroduceIndex.contentItemId));
            });



            return 1;
        }
    }
}
