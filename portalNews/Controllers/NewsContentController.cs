using System;
using System.Collections;
using Microsoft.Extensions.Logging;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using YesSql;
using Microsoft.AspNetCore.Mvc;
using portalNews.Models;
using portalNews.Controllers.ResponseModel;
using System.Data;

namespace portalNews.Controllers
{


    public class demo
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class NewsContentController : Controller
    {

        private readonly ILogger<NewsContentController> _logger;
        private readonly ISession _session;

        private readonly DbOperation _dbCon;

        public NewsContentController(ILogger<NewsContentController> logger, ISession session,
            DbOperation db)
        {
            _logger = logger;
            _session = session;
            _dbCon = db;
        }


        // 测试
        public JsonResult Index()
        {

            return Json(new demo
            {
                id = 19,
                name = "dwqd",
            });
        }


        // 获取所有news 列表

        [HttpGet]
        public async Task<JsonResult> AllNews()
        {

           
                // 改成 ef TODO
                using (IDbConnection con = _dbCon.Connnection)
                {

                    try
                    {

                        var all = await con.QueryAsync<DocumentResponseModel>("select nm.Id, nm.Content from Document as nm  " +
                                "inner join " +
                                "(SELECT * FROM ContentItemIndex where contentType = @NewsModel and Published = @flag) " +
                                "as m on m.DocumentId = nm.Id ", new { NewsModel = nameof(NewsModel), flag = true });

                        // 
                        var res = new ArrayList(10);

                        foreach (var doc in all)
                        {


                            res.Add(jsonParse(doc.Content, doc.Id));
                        }
                        if (res.Count < 0)
                        {
                            return Json(null);
                        }
                        return Json(res);

                    }
                    catch (Exception e)
                    {


                        // TODO error

                        return Json(e);
                    }

            }


           

        }



        [HttpGet]
        //[Route("NewsContent/OneNews/{id?}")]
        public async Task<JsonResult> OneNews(string id)
        {

        
            _logger.LogInformation("docId----> {id}", id);

            if (string.IsNullOrEmpty(id))
            {
                return Json(null);
            }
            

                using (IDbConnection con = _dbCon.Connnection)
                {

                    try
                    {
                        var first = await con.QueryFirstAsync<DocumentResponseModel>("select id, " +
                           "content from Document where id = @id", new { id = id });
                        if (first == null)
                        {

                            return Json(null);
                        }

                        var json = JObject.Parse(first.Content);

                        var res = new NewsResponseModel
                        {
                            DocumentId = first.Id,
                            Content = json[nameof(NewsModel)],
                        };

                        return Json(res);


                    }
                    catch (Exception e)
                    {
                        return Json(e);
                    }

        }
                   


            
        }




        private NewsListResponseModel jsonParse(string json, int  documentId = -1 )
        {


            // exception TODO
            var parse = JObject.Parse(json);

            var model = parse[nameof(NewsModel)];

            return new NewsListResponseModel
            {
                DocumentId = documentId,
                ContentItemId = parse[nameof(NewsListResponseModel.ContentItemId)].ToString(),
                Title = model[nameof(NewsModel.Title)].ToString(),
                Author = model[nameof(NewsModel.Authtor)].ToString(),
                CoverImageUrl = model[nameof(NewsModel.CoverImgUrl)].ToString(),
                CreateAt = model[nameof(NewsModel.CreatedAt)].ToString(),
                Description = model[nameof(NewsModel.Description)].ToString(),

            };
            


        }

    }
}
