using BlazorDesk.DataModels.Interfaces;
using Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.DataModels.Requests
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
