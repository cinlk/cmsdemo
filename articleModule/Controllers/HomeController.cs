using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Debug;

using articleModule.Data;

namespace Module1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleDbContext _db;

        public HomeController(ArticleDbContext context)
        {
            _db = context;
        }



        public JsonResult Index()
        {

            var res = (from m in _db.Document where m.Id == 341  select m);


            //var one = _db.ArticleContentIndex.FirstOrDefault();


            //var res = (from m in _db.Document
            //           join s in (from m in _db.ArticleContentIndex
            //                      join n
            //                       in _db.ContentItemIndex on m.ContentItemId equals n.ContentItemId
            //                      where n.Published == true
            //                      select new
            //                      {
            //                          m.Id,
            //                          m.DocumentId

            //                      })  on m.Id equals s.DocumentId 
            //            select m ).Skip(1).Take(1).ToList();
                                                     

            return Json(res);
        }
    }
}
