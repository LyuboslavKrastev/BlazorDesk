using Shared.Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.AppModels.Management.Binding
{
    public class StatusCreationBindingModel
    {
        [Required]
        [MinLength(RequestStatusConstants.NameMinLength)]
        [MaxLength(RequestStatusConstants.NameMaxLength)]
        public string Name { get; set; }
    }
}
