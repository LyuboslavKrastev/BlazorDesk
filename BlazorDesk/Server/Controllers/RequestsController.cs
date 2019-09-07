using BlazorDesk.AppModels;
using BlazorDesk.AppModels.Binding;
using BlazorDesk.AppModels.View;
using BlazorDesk.DataModels.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlazorDesk.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        ICollection<Request> fakeRequests = new List<Request>
{
                new Request
            {
                Id = 1,
                Subject = "Subject 1",
                Description = "Description!"
            },
            new Request
            {
                Id = 2,
                Subject = "Subject 2",
                Description = "Description!"
            }
};
        [HttpGet("{id}")]
        public RequestDetailsViewModel Get(int id)
        {
            return fakeRequests.Where(r => r.Id == id).Select(r => new RequestDetailsViewModel
            {
                Id = r.Id,
                Subject = r.Subject,
                Description = r.Description
            }).FirstOrDefault();
        }

        [HttpGet]
        public IEnumerable<RequestListingViewModel> Get()
        {
            return fakeRequests.Select(r => new RequestListingViewModel
            {
                Id = r.Id,
                Subject = r.Subject,
                Requester = r.Requester
            });
        }
        [HttpPost]
        public IActionResult Post(RequestCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var request = new Request
            {
                Subject = model.Subject,
                Description = model.Description,
            };

            fakeRequests.Add(request);

            return CreatedAtAction("Post", model);

        }
    }
}