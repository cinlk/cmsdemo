using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using news.Models;

namespace news.ViewModels
{
    public class NewsViewModel : IValidatableObject
    {



        [Required]
        public string Title { get; set; }

        
        public string Authtor { get; set; }

       
        public DateTime? CreatedAt { get; set; }

        [Required]
        public string CoverImgUrl { get; set; }

        // ??
        [BindNever]
        public NewsModel News { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // 需要引用 DependencyInjection 库
            var v = validationContext.GetService<IStringLocalizer<NewsModel>>();
            var time = validationContext.GetService<IClock>();

            if (CreatedAt.HasValue)
            {
                if (time.UtcNow < CreatedAt.Value)
                {
                    yield return new ValidationResult(v["创建时间必须小于当前时间"], new[]
                    {
                        nameof(CreatedAt)
                    });
                }
            }

        }
    }
}
