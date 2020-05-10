using System;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;

using OrchardCore.Data.Migration;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;

using portalIndex.Models;
using portalIndex.Indexes;


namespace portalIndex.Migrations
{
    public class ClientExampleMigration : DataMigration
    {

        private readonly IContentDefinitionManager _contentDefineManager;

        public ClientExampleMigration(IContentDefinitionManager cm)
        {
            _contentDefineManager = cm;
        }


        public int Create()
        {

            _contentDefineManager.AlterPartDefinition(nameof(ClientExampleModel), part =>
            {
                part.WithField(nameof(ClientExampleModel.content), conf =>
                {
                    conf.OfType(nameof(HtmlField))
                    .WithDisplayName("content")
                    .WithEditor("Wysiwyg")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "example's content",
                        Required = false
                    });
                });

            });


            _contentDefineManager.AlterTypeDefinition(nameof(ClientExampleModel), conf => {

                conf.Creatable()
                .Listable().Draftable()
                .WithPart(nameof(ClientExampleModel));
            });


            SchemaBuilder.CreateMapIndexTable(nameof(ClientExampleIndex), table => {

                table.Column<string>(nameof(ClientExampleIndex.title))
                .Column<string>(nameof(ClientExampleIndex.coverImg))
                .Column<DateTime>(nameof(ClientExampleIndex.createdTime))
                .Column<string>(nameof(ClientExampleIndex.contentItemId));

            });

            return 1;
        }


    }
}
