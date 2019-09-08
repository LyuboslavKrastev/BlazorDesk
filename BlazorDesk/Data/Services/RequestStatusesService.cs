using BlazorDesk.Data.Services.Interfaces;
using BlazorDesk.Data.Services.BaseClasses;
using BlazorDesk.Data.Services.Repository.Interfaces;
using BlazorDesk.Data.Models.Requests;

namespace BlazorDesk.Data.Services
{
    public class RequestStatusesService : BaseDbService<RequestStatus>, IRequestStatusesService, 
        IDbService<RequestStatus>
    {
        public RequestStatusesService(IRepository<RequestStatus> repository) : base(repository)
        {
        }
    }
}
