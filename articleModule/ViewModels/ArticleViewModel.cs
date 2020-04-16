
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using articleModule.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentFields.Fields;
using OrchardCore.Media.Fields;
using OrchardCore.Modules;

namespace articleModule.ViewModels
{
    public class ArticleViewModel : IValidatableObject
    {

        //[Required]
        //public TextField authorName { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        public string CoverImage { get; set; }


        //public HtmlField body { get; set; }

        [BindNever]
        public ArticleModel article { get; set; }



       


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var T = validationContext.GetService<IStringLocalizer<ArticleViewModel>>();
            var clock = validationContext.GetService<IClock>();

            if (string.IsNullOrEmpty(CoverImage))
            {
                
                yield return new ValidationResult(T["empty cover image."], new[] { nameof(CoverImage) });
                
            }

            
        }
    }
}
