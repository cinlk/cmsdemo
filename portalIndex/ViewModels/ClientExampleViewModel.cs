using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

using portalIndex.Models;

namespace portalIndex.ViewModels
{
    public class ClientExampleViewModel : IValidatableObject
    {


        [Required]
        public string coverImg { get; set; }


        public DateTime createdTime { get; set; }

        [Required]
        public string title { get; set; }

        [BindNever]
        public ClientExampleModel clientExampleModel { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            var T = validationContext.GetService<IStringLocalizer<ProductDesModel>>();
            var clock = validationContext.GetService<IClock>();

            if (clock.UtcNow < createdTime)
            {
                  yield return new ValidationResult(T["The create time illegal."], new[] { nameof(createdTime) });
             }
            
        }
    }
}
