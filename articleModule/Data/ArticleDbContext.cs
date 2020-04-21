using System;
using articleModule.Indexes;
using Microsoft.EntityFrameworkCore;
using OrchardCore.ContentManagement.Records;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging.Console;
using OrchardCore.ContentManagement;
using YesSql;

namespace articleModule.Data
{
    public class ArticleDbContext : DbContext
    {

        //// 输出到Console
        //public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
        //     new ConsoleLoggerProvider(null)
        //});

        //public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
        //    new DebugLoggerProvider()
        //});


        public static readonly ILoggerFactory MyLoggerFactory
                = LoggerFactory.Create(builder => { builder.AddConsole(); });


        //public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
        //    new ConsoleLoggerProvider((category, level)  => category == DbLoggerCategory.Database.Command.Name&& level == LogLevel.Information, true)
        //});


        public ArticleDbContext(DbContextOptions<ArticleDbContext> options): base(options)
        {
           
        }



        protected override void OnConfiguring(DbContextOptionsBuilder opbuilder)
        {
            base.OnConfiguring(opbuilder);

            opbuilder.UseLoggerFactory(MyLoggerFactory);

        }

        public DbSet<ArticleContentIndex> ArticleContentIndex { get; set; }

        public DbSet<ContentItemIndex> ContentItemIndex { get; set; }

        public DbSet<ContentItem> ContentItem { get; set; }

        public DbSet<Document> Document { get; set; }


        // InvalidOperationException: The entity type 'HtmlField' requires a primary key to be defined.
        // If you intended to use a keyless entity type call 'HasNoKey()'.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ArticleContentIndex>(entity =>
            //    entity.HasNoKey()
            //    .ToView("")
            //    );
        }

    }
}
