using BlazorDesk.Data.Models.Requests;
using System.Threading.Tasks;

namespace BlazorDesk.Data.Services.Interfaces
{
    public interface IRepliesService : IDbService<RequestReply>
    {
        Task AddAsync(int requestId, string userId, bool isTechnician, string description);
    }
}
