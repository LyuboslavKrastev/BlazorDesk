using System.Threading.Tasks;
using BlazorDesk.Data.Models.Solution;

namespace BlazorDesk.Data.Services.Interfaces
{
    public interface ISolutionsService : IDbService<Solution>
    {
        Task<Solution> ByIdAndIncreaseViews(int id);
    }
}