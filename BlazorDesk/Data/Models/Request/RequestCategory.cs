using BlazorDesk.DataModels.Interfaces;
using Shared.Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.Data.Models.Requests
{
    public class RequestCategory : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RequestCategoryConstants.NameMinLength)]
        [MaxLength(RequestCategoryConstants.NameMaxLength)]
        public string Name { get; set; }
    }
}
