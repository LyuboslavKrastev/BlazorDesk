using BlazorDesk.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDesk.Data.Services.BaseClasses;
using BlazorDesk.Data.Services.Repository.Interfaces;
using BlazorDesk.Data.Models.Requests;

namespace BlazorDesk.Data.Services
{
    public class NotesService : BaseDbService<RequestNote>, INotesService, IDbService<RequestNote>
    {
        private readonly IRequestsService requestService;

        public NotesService(IRepository<RequestNote> repository, IRequestsService requestService) : base(repository)
        {
            this.requestService = requestService;
        }

        public async Task AddManyAsync(IEnumerable<int> requestIds, string userId, string userName, bool isTechnician, string noteDescription)
        {
            foreach (var id in requestIds)
            {
                Request request = this.requestService.ById(id).FirstOrDefault();

                if (request == null)
                {
                    throw new ArgumentException("Invalid request id");
                }

                if (!isTechnician && userId != request.RequesterId)
                {
                    throw new InvalidOperationException("Users can only add notes to their own requests");
                }

                RequestNote note = new RequestNote
                {
                    RequestId = id,
                    Description = noteDescription,
                    Author = userName
                };

                await this.repository.AddAsync(note);
                await this.repository.SaveChangesAsync();
            }
        }
    }
}
