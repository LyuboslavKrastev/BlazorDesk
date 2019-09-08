using System.Threading.Tasks;
using BlazorDesk.Data.Models.Requests;

namespace BlazorDesk.Data.Services.Interfaces
{
    public interface ICategoriesService : IDbService<RequestCategory>
    {
        Task Edit(int id, string name);
    }
}