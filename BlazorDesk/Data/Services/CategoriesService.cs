using BlazorDesk.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BlazorDesk.Data.Services.BaseClasses;
using BlazorDesk.Data.Services.Repository.Interfaces;
using BlazorDesk.Data.Models.Requests;

namespace BlazorDesk.Data.Services
{
    public class CategoriesService : BaseDbService<RequestCategory>, ICategoriesService, IDbService<RequestCategory>
    {
        public CategoriesService(IRepository<RequestCategory> repository) : base(repository)
        {
        }

        public async Task Edit(int id, string name)
        {
            var category = await this.repository.All().FirstAsync(c => c.Id == id);

            category.Name = name;

            await this.SaveChangesAsync();
        }
    }
}
