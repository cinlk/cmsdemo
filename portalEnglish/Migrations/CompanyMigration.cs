using System;
using OrchardCore.ContentFields.Fields;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;

using portalEnglish.Models;
using portalEnglish.Indexes;

namespace portalEnglish.Migrations
{
    public class CompanyMigration : DataMigration
    {

        private readonly IContentDefinitionManager _contentDefinitionManager;

        public CompanyMigration(IContentDefinitionManager cm)
        {
            _contentDefinitionManager = cm;
        }


        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(EnglishCompanyModel), part =>
            {
                part.WithField(nameof(EnglishCompanyModel.CompanyDetail), conf =>
                {
                    conf.OfType(nameof(TextField))
                    .WithDisplayName("company profile detail")
                    .WithEditor("TextArea")
                    .WithSettings(new TextFieldSettings
                    {
                        Required = true 
                    });
                });
            });

            _contentDefinitionManager.AlterTypeDefinition(nameof(EnglishCompanyModel), conf =>
            {
                conf.Creatable()
                .Listable().Draftable().WithPart(nameof(EnglishCompanyModel));
            });


            SchemaBuilder.CreateMapIndexTable(nameof(VirtaiEnglishCompanyIndex), table =>
            {
                table.Column<string>(nameof(VirtaiEnglishCompanyIndex.ContentItemId), c => c.NotNull())
                .Column<string>(nameof(VirtaiEnglishCompanyIndex.CompanyProfileImgUrl), c => c.NotNull())
                .Column<string>(nameof(VirtaiEnglishCompanyIndex.CompanyBackgroundImgUrl), c => c.NotNull())
                .Column<string>(nameof(VirtaiEnglishCompanyIndex.Title), c => c.WithLength(50))
                .Column<string>(nameof(VirtaiEnglishCompanyIndex.SubTitle));
            });

            return 1;
        }






    }
}
