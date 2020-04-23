using System;
using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;

namespace portalJobs.Models
{
    public class JobModel : ContentPart
    {

        public string name { get; set; }

        // 枚举
        public string type { get; set; }

        public int count { get; set; }

        // 枚举
        public JobLocation location { get; set; }

        public DateTime publishedTime { get; set; }


        public string contactEmail { get; set; }

        public string contactPhone { get; set; }



        public TextField requiredList { get; set; }

        public TextField responsileList { get; set; }



    }


    public enum JobLocation
    {
        Beijing,
        Shanghai,
        Hangzhou,
        Chendu
    }
}
