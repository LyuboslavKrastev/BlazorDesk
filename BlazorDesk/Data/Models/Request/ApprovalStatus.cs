using BlazorDesk.DataModels.Interfaces;
using Shared.Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.Data.Models.Requests
{
    public class ApprovalStatus : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RequestStatusConstants.NameMinLength)]
        [MaxLength(RequestStatusConstants.NameMaxLength)]
        public string Name { get; set; }
    }
}
