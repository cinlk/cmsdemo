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
    public class ProductDesMigration : DataMigration
    {

        private readonly IContentDefinitionManager _contentDefineManager;


        public ProductDesMigration(IContentDefinitionManager cm)
        {
            _contentDefineManager = cm;
        }


        public int Create()
        {

            _contentDefineManager.AlterPartDefinition(nameof(ProductDesModel), part =>
            {
                part.WithField(nameof(ProductDesModel.des), conf =>
                {
                    conf.OfType(nameof(TextField))
                    .WithDisplayName("product description")
                    .WithEditor("TextArea")
                    .WithSettings(new TextFieldSettings
                    {

                        Required = false
                    });
                });

            });


            _contentDefineManager.AlterTypeDefinition(nameof(ProductDesModel), conf => {

                conf.Creatable()
                .Listable().Draftable()
                .WithPart(nameof(ProductDesModel));
            });


            SchemaBuilder.CreateMapIndexTable(nameof(ProductDesIndex), table => {

                table.Column<string>(nameof(ProductDesIndex.icon));
              


            });

            return 3;
        }

        public int UpdateFrom1()
        {
            // 加入contentItemid 字段

            SchemaBuilder.AlterTable(nameof(ProductDesIndex), table => {
                table.AddColumn<string>(nameof(ProductDesIndex.contentItemId));
            });

            return 2;
        }


        // add language
        public int UpdateFrom2()
        {

            SchemaBuilder.AlterTable(nameof(ProductDesIndex), table => {
                table.AddColumn<string>(nameof(ProductDesIndex.Laguange), c => {
                    c.NotNull();
                    c.WithDefault(LaguangeType.Chinese);
                });
            });
            return 3; 
        }
    }
}
