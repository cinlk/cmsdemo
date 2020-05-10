using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using portalEnglish.Models;
using System.Collections.Generic;



namespace portalEnglish.ViewModels
{
    public class CompanyViewModel : IValidatableObject
    {

         
        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }


        [Required]
        public string CompanyBackgroundImgUrl { get; set; }

        [Required]
        public string CompanyProfileImgUrl { get; set; }



        [BindNever]
        public EnglishCompanyModel EnglishCompanyModel { get; set; }
        



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            // check subTitle
            if (string.IsNullOrEmpty(SubTitle))
            {
                yield return new ValidationResult("ok");
            }
            // TODO
           
        }
    }
}
