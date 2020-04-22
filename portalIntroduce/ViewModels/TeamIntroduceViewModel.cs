using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

using portalIntroduce.Models;


namespace portalIntroduce.ViewModels
{
    public class TeamIntroduceViewModel 
    {

        [Required]
        public string avatarImg { get; set; }

        [BindNever]
        public TeamIntroduceModel teamIntroduceModel { get; set; }

       
    }
}
