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
    public class TeamIntroduceMigration : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefineManager;

        public TeamIntroduceMigration(IContentDefinitionManager cm)

        {
            _contentDefineManager = cm;
        }


        public int Create()
        {
            _contentDefineManager.AlterPartDefinition(nameof(TeamIntroduceModel), part => {
                part.WithField(nameof(TeamIntroduceModel.bio), conf =>
                {
                    conf.OfType(nameof(HtmlField))
                    .WithDisplayName("person bio")
                    .WithEditor("Wysiwyg")
                    .WithSettings(new HtmlFieldSettings
                    {
                        Hint = "self bio",
                    });


                });

            });

            _contentDefineManager.AlterTypeDefinition(nameof(TeamIntroduceModel), conf => {
                conf.Creatable()
                .Listable().Draftable()
                .WithPart(nameof(TeamIntroduceModel));

            });

            SchemaBuilder.CreateMapIndexTable(nameof(TeamIntroduceIndex), table => {
                table.Column<string>(nameof(TeamIntroduceIndex.avatarImg))
               .Column<string>(nameof(TeamIntroduceIndex.contentItemId));

            });


            return 1;
        }
    }
}
