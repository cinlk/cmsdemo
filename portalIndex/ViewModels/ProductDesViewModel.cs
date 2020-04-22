using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

using portalIndex.Models;

namespace portalIndex.ViewModels
{
    public class ProductDesViewModel : IValidatableObject
    {

        [Required]
        public string icon { get; set; }
        

        [BindNever]
        public ProductDesModel productDesModel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
             var T = validationContext.GetService<IStringLocalizer<ProductDesModel>>();

            if (string.IsNullOrEmpty(icon))
            {

                yield return new ValidationResult(T["need icon image."], new[] { nameof(ProductDesModel.icon) });

            }

        }
    }
}
