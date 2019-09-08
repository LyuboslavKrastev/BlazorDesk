using Shared.Constants.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesk.AppModels.Binding.Management.ViewModel
{
    public class CategoryEditingBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(RequestCategoryConstants.NameMinLength)]
        [MaxLength(RequestCategoryConstants.NameMaxLength)]
        public string Name { get; set; }
    }
}
