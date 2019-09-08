using BlazorDesk.Data.Services.Interfaces;
using BlazorDesk.Data.Services.Repository;
using System.Linq;
using System.Threading.Tasks;
using BlazorDesk.Data.Services.BaseClasses;
using Microsoft.EntityFrameworkCore;
using BlazorDesk.Data.Models.Solution;

namespace BlazorDesk.Data.Services
{
    public class SolutionsService : BaseDbService<Solution>, ISolutionsService, IDbService<Solution>
    {


        public SolutionsService(DbRepository<Solution> repository) : base(repository)
        {
        }

        public async Task<Solution> ByIdAndIncreaseViews(int id)
        {
            Solution solution = base.ById(id)
                .Include(s => s.Author)
                .FirstOrDefault();

            solution.Views++;

            await this.SaveChangesAsync();

            return solution;
        }
    }
}
