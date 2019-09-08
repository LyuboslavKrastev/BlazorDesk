using BlazorDesk.AppModels.Management.Binding;
using BlazorDesk.AppModels.View;
using System.Collections.Generic;

namespace BlazorDesk.AppModels.Management
{
    public class CategoryIndexModel
    {
        public ICollection<CategoryViewModel> CategoryViewModels { get; set; }

        public CategoryCreationBindingModel CategoryCreationBindingModel { get; set; }
    }
}
