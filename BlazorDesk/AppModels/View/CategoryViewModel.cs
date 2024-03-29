﻿using Shared.Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.AppModels.View
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RequestCategoryConstants.NameMinLength)]
        [MaxLength(RequestCategoryConstants.NameMaxLength)]
        public string Name { get; set; }
    }
}
