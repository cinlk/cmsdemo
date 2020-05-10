using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using portalEnglish.Models;
using System.Collections.Generic;

namespace portalEnglish.ViewModels
{
    public class ContactViewModel : IValidatableObject
    {

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string BackgroundImgUrl { get; set; }

        [BindNever]
        public EnglishContactModel EnglishContactModel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // check
            if (String.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult("ok");
            }
            
        }
    }
}
