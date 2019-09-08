using Shared.Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.AppModels.Management.Binding

{
    public class CategoryCreationBindingModel
    {
        [Required]
        [MinLength(RequestCategoryConstants.NameMinLength)]
        [MaxLength(RequestCategoryConstants.NameMaxLength)]
        public string Name { get; set; }
    }
}
