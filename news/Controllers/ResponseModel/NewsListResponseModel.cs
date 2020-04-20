using System;
namespace news.Controllers.ResponseModel
{
    public class NewsListResponseModel
    {



        public int DocumentId { get; set; }

        public string ContentItemId { get; set; }    

        public string CreateAt { get; set; }

        public string CoverImageUrl { get; set; }

        public string Title { get; set; } 

        public string Author { get; set; }

        public string Description { get; set; }

    }
}
