using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using portalJobs.Models;

namespace portalJobs.ViewModels
{
    public class JobViewModel
    {

        [Required]
        public string name { get; set; }

        
        [Required]
        public string type { get; set; }

        [Required]
        public int count { get; set; }

        // 枚举
        [Required]
        public JobLocation location { get; set; }

        public DateTime publishedTime { get; set; }

        [Required]
        public string contactEmail { get; set; }

        [Required]
        public string contactPhone { get; set; }


        [BindNever]
        public JobModel jobModel { get; set; }

    }
}
