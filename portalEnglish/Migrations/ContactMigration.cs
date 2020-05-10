
using OrchardCore.Data.Migration;

using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;

using portalEnglish.Models;
using portalEnglish.Indexes;

namespace portalEnglish.Migrations
{
    public class ContactMigration : DataMigration
    {

        private readonly IContentDefinitionManager _contentDefineManager;


        public ContactMigration(IContentDefinitionManager cm)
        {
            _contentDefineManager = cm;

        }

        public int Create()
        {

            //加了 才显示 content 的属性在界面 ？？
            _contentDefineManager.AlterPartDefinition(nameof(EnglishContactModel), part =>
            {
                part.WithField(nameof(EnglishContactModel.bools), conf =>
                {
                    conf.OfType(nameof(BooleanField))
                    .WithDisplayName("defualt boolean").WithDescription("extra");
                });
            });


            _contentDefineManager.AlterTypeDefinition(nameof(EnglishContactModel), conf => {

                conf.Creatable()
                .Listable().Draftable().WithPart(nameof(EnglishContactModel));
            });


            SchemaBuilder.CreateMapIndexTable(nameof(VirtaiEnglishContactIndex), table => {

                table.Column<string>(nameof(VirtaiEnglishContactIndex.ContentItemId))
                .Column<string>(nameof(VirtaiEnglishContactIndex.Address))
                .Column<string>(nameof(VirtaiEnglishContactIndex.Email))
                .Column<string>(nameof(VirtaiEnglishContactIndex.Number))
                .Column<string>(nameof(VirtaiEnglishContactIndex.BackgroundImgUrl));

            });


            return 1;

            
        }

        //public int UpdateFrom1()
        //{

         

        //    _contentDefineManager.AlterTypeDefinition(nameof(EnglishContactModel), conf =>
        //    {
        //        conf.Creatable()
        //        .Listable().Draftable().WithPart(nameof(EnglishContactModel));
        //    });

        //    return 2;
        //}
    }
}
