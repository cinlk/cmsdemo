using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrchardCore.ContentManagement;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentManagement.Records;
using articleModule.Models;
using articleModule.Indexes;
using YesSql;
//using MySql.Data.MySqlClient;
using Dapper;
using System.Data;





namespace articleModule.Controllers
{


    public class demoDocument
    {

        public int Id
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public Object ContentObj
        {
            get;
            set;
        }
    }

    public class ArticleController: Controller
    {

        private readonly ILogger<ArticleController> _logger;
        private readonly ISession _session;

        // db
        private readonly DbDapper _dbCon;


        public ArticleController(ILogger<ArticleController> logger, ISession session, DbDapper db)
        {
            _logger = logger;
            _session = session;
            _dbCon = db;

        }

        // 分页 TODO

       [HttpGet]
        public  async Task<JsonResult> Article(int  pageIndex = 1)
        {


            // limit = 10
            var pageSize = 10;

            pageIndex = (pageIndex - 1) * (pageSize);


            var totalPages = 0;
          




            _logger.LogInformation("============> start query {pageindex}",  pageIndex);

            
            try
            {
                var count =  _dbCon.ml.Query<int>("select count(1) from document as d join  (select a.id, a.documentId from articleContentIndex as a left join contentItemIndex " +
                    "as c on c.contentItemid = a.contentItemId where  c.published = true) as m on d.id = m.documentid ").Single();
                totalPages = (int)Math.Ceiling((double)count /pageSize);
                _logger.LogInformation("============> target {totalPages} ", totalPages);


                // 根据contentitemindex published 的文章
                var list = await _dbCon.ml.QueryAsync<demoDocument>("select d.id, d.type, d.content  from document as d join " +
                    "(select a.id, a.documentId from articleContentIndex as a left join contentItemIndex as c " +
                    "on c.contentItemid = a.contentItemId where  c.published = true) as m on d.id = m.documentid limit @pageSize offset @offset", new {
                         pageSize = pageSize,
                         offset = pageIndex,
                    });

                foreach (var i in list)
                {
                    JObject obj = JObject.Parse(i.Content);
                    i.ContentObj = obj;

                }


                // 返回json 数据
                return Json(list.ToList());



            }
            catch (Exception e)
            {
                _logger.LogError(e, "error");

            }


            return Json(null);
        }

        //// 根据 contentitem id 查询具体的内容

        [HttpGet]
        //[Route("Article/ArticleContent/{id?}")]
        public async Task<JsonResult> ArticleContent(string? id)
        {


            var ids = id ?? "";


            _logger.LogInformation("docid ----> {id}", ids);
            try
            {
                var item = await _dbCon.ml.QueryFirstAsync<demoDocument>(" select * from document where id = @id", new { id = ids });

                item.ContentObj = JObject.Parse(item.Content);
                return Json(item);

            }
            catch (Exception e)
            {

                _logger.LogError(e, "error");
            }



            return Json(null);

        }


    }

       
}
