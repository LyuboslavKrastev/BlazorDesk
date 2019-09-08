using BlazorDesk.Data.Services.BaseClasses;
using BlazorDesk.Data.Services.Repository.Interfaces;
using BlazorDesk.DataModels.Interfaces;

namespace BlazorDesk.Data.Services
{
    public class AttachmentsService<T> : BaseDbService<T>
        where T: class, IEntity, IAttachment 
    {
        public AttachmentsService(IRepository<T> repository) : base(repository)
        {
        }


    }
}
