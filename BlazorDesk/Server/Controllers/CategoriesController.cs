using BlazorDesk.AppModels;
using BlazorDesk.AppModels.View;
using BlazorDesk.DataModels.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlazorDesk.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        ICollection<RequestCategory> fakeCategories = new List<RequestCategory>
        {
            new RequestCategory
            {
                Id= 1,
                Name = "First Category"
            },
            new RequestCategory
            {
                Id=2,
                Name = "Second Category"
            }
        };

        [HttpGet("{id}")]
        public CategoryViewModel Get(int id)
        {
            return this.GetViewModel(fakeCategories).FirstOrDefault();
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> Get()
        {
            return this.GetViewModel(fakeCategories);
        }

        private IEnumerable<CategoryViewModel> GetViewModel(IEnumerable<RequestCategory> collection)
        {
            return collection.Select(c =>
                new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                });
        }
    }
}