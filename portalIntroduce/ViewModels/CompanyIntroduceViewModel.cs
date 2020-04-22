
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

using portalIntroduce.Models;

namespace portalIntroduce.ViewModels

{
    public class CompanyIntroduceViewModel 
    {

        [Required]
        public string title { get; set; }

       
        public string coverImg { get; set; }

        [BindNever]
        public CompanyIntroduceModel companyIntroduceModel { get; set; }

        
    }
}
