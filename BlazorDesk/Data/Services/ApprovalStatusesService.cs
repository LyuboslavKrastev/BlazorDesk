using BlazorDesk.Data.Services.Interfaces;
using BlazorDesk.Data.Services.BaseClasses;
using BlazorDesk.Data.Services.Repository.Interfaces;
using BlazorDesk.Data.Models.Requests;

namespace BlazorDesk.Data.Services
{
    public class ApprovalStatusesService : BaseDbService<ApprovalStatus>, IApprovalStatusesService, IDbService<ApprovalStatus>
    {
        public ApprovalStatusesService(IRepository<ApprovalStatus> repository) : base(repository)
        {
        }
    }
}
