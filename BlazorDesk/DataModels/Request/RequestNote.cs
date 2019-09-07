using BlazorDesk.DataModels.Interfaces;
using Constants.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.DataModels.Requests
{
    public class RequestNote : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RequestConstants.DescriptionMinLength)]
        [MaxLength(RequestConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        [Required]
        public string Author { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }
    }
}
