using System;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Fields;

using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;

using news.Models;
using news.Indexes;

namespace news.Migrations
{
    public class NewsMigration : DataMigration
    {


        private readonly IContentDefinitionManager _contentDefineManager;


        public NewsMigration(IContentDefinitionManager cm)
        {
            _contentDefineManager = cm;
        }

        public int Create()
        {

            // 设置 ocntent part
            _contentDefineManager.AlterPartDefinition(nameof(NewsModel),
                part =>
                {
                    part.WithField(nameof(NewsModel.Description), conf =>
                        conf.OfType(nameof(TextField))
                        .WithDisplayName("description")
                        .WithEditor("TextArea")
                        .WithSettings( new TextFieldSettings
                        {
                            Required = false
                        })

                    );

                    part.WithField(nameof(NewsModel.ContentBody), conf =>
                        conf.OfType(nameof(HtmlField))
                        .WithDisplayName("content")
                        .WithEditor("Wysiwyg")
                        .WithSettings(new HtmlFieldSettings
                        {
                            Hint = "内容"
                        })
                     );
                }
           );

            // 设置 content type

            _contentDefineManager.AlterTypeDefinition(nameof(NewsModel), conf =>
            {
                conf.Creatable()
                .Listable()
                .WithPart(nameof(NewsModel));
            }
            );



            // 创建news index
            SchemaBuilder.CreateMapIndexTable(nameof(NewsModelIndex), table => {
                table.Column<string>(nameof(NewsModel.Authtor), c => c.WithLength(100))
                .Column<string>(nameof(NewsModel.CoverImgUrl))
                .Column<string>(nameof(NewsModel.Title), c => c.WithLength(300))
                .Column<DateTime>(nameof(NewsModel.CreatedAt));
            });


            return 2;

        }


        public int UpdateFrom1()
        {
            SchemaBuilder.AlterTable(nameof(NewsModelIndex), table =>
            {
                table.AddColumn<String>(nameof(NewsModelIndex.ContentItemId));
            });

            return 2;
        }
    }
}
