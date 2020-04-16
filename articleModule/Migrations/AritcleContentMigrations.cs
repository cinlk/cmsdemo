using System;
using Microsoft.Extensions.Logging;
using articleModule.Models;
using articleModule.Indexes;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;


namespace articleModule.Migrations
{
    public class ArticleContentMigrations : DataMigration
    {

        private readonly IContentDefinitionManager _contentDefineManager;

        private readonly ILogger<ArticleContentMigrations> _logger;

        public ArticleContentMigrations(IContentDefinitionManager cm, ILogger<ArticleContentMigrations> logger)
        {
            _contentDefineManager = cm;
            _logger = logger;

        }



        // 第一次 enable module  会执行

        public int Create()
        {

            _logger.LogWarning("start create ----->");

            _contentDefineManager.AlterPartDefinition(nameof(ArticleModel),
                action => action.WithField(nameof(ArticleModel.authorName), action =>
                action.OfType(nameof(TextField))
                .WithDisplayName("author name")
                .WithEditor("TextArea")
                .WithSettings(new TextFieldSettings {
                    Hint = "author's name",
                    Required = true

                }))
            );
            _contentDefineManager.AlterPartDefinition(nameof(ArticleModel),
                action => action.WithField(nameof(ArticleModel.Content), action =>
                action.OfType(nameof(HtmlField))
                .WithDisplayName("Html Body")
                .WithEditor("Wysiwyg")
                .WithSettings(new HtmlFieldSettings
                {
                    Hint = "content body"
                }
                )));

            _contentDefineManager.AlterTypeDefinition(nameof(ArticleModel), action =>
            action.Creatable()
            .Listable()
            .WithPart(nameof(ArticleModel))
            );


            _logger.LogWarning("create  articleContentIndex table");

            SchemaBuilder.CreateMapIndexTable(nameof(ArticleContentIndex),
                table => table.Column<string>("coverImage")
                .Column<string>(nameof(ArticleContentIndex.Title))


                );



            return 2;
        }


        // module enable 后  执行这里的方法 updatefromX
        // updateFrom  机制 
        public int UpdateFrom3()
        {

           
            _logger.LogWarning("update 2 articleContentIndex table");


                // 没有生效？？ 在part 里
                _contentDefineManager.AlterPartDefinition(nameof(ArticleModel),
                  action =>
                  {
                      action.WithField(nameof(ArticleModel.authorName), action =>
                      action.OfType(nameof(TextField))
                      .WithDisplayName("author name")
                      .WithEditor("Standard")
                      .WithSettings(new TextFieldSettings
                      {
                          Hint = "author's name",
                          Required = true

                      }));

                      action.WithField(nameof(ArticleModel.Content), action =>
                        action.OfType(nameof(HtmlField))
                        .WithDisplayName("Html Body")
                        .WithEditor("Wysiwyg")
                        //.WithDisplayMode("Standard")
                        .WithSettings(new HtmlFieldSettings
                        {
                            Hint = "content body"
                        }
                    ));

                  }
              
                );

                //_contentDefineManager.AlterPartDefinition(nameof(ArticleModel),
                //    action => 
                //);

            

            if (_contentDefineManager.GetTypeDefinition(nameof(ArticleContentIndex)) == null)
            {
                _contentDefineManager.AlterTypeDefinition(nameof(ArticleModel), action =>
                   action.Creatable()
                   .Listable()
                   .WithPart(nameof(ArticleModel))
                );

            }


           

            //SchemaBuilder.CreateMapIndexTable(nameof(ArticleContentIndex),
            //    table => table.Column<string>("coverImage")
            //    .Column<string>(nameof(ArticleContentIndex.Title))
            //    .Column<String>(nameof(ArticleContentIndex.ContentItemId))

            //    );




            //SchemaBuilder.AlterTable(nameof(ArticleContentIndex),
            //    table => table.AddColumn<string>(nameof(ArticleContentIndex.ContentItemId)));

            return 2;
        }


        //  没有工作？
        //public int UpdateFrom2()
        //{

        //    _logger.LogInformation("update from2 ");
        //    SchemaBuilder.AlterTable(nameof(ArticleContentIndex),
        //        table => table.DropColumn(nameof(ArticleContentIndex.ContentItemId))
        //        );
            

        //    return 3;
        //}


        //public int UpdateFrom3()
        //{

        //}





    }
}
