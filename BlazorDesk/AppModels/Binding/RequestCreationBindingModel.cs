using Shared.Constants.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.AppModels.Binding
{
    public class RequestCreationBindingModel
    {
        [Required]
        [MinLength(RequestConstants.SubjectMinLength)]
        [MaxLength(RequestConstants.SubjectMaxLength)]
        public string Subject { get; set; }

        [Required]
        [MinLength(RequestConstants.DescriptionMinLength)]
        [MaxLength(RequestConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;

        [Required]
        [MinLength(2)]
        public string Category { get; set; }

        //[DataType(DataType.Upload)]
        //public ICollection<IFormFile> Attachments { get; set; }
    }
}
