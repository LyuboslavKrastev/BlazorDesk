using BlazorDesk.AppModels;
using BlazorDesk.AppModels.Binding;
using BlazorDesk.AppModels.View;
using BlazorDesk.Data.Models;
using BlazorDesk.Data.Models.Requests;
using BlazorDesk.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDesk.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RequestsController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IRequestsService requestsService;
        public RequestsController(UserManager<User> userManager, IRequestsService requestsService)
        {
            this.userManager = userManager;
            this.requestsService = requestsService;
        }
        [HttpGet("{id}")]
        public RequestDetailsViewModel Get(int id)
        {
            string userId = this.userManager.GetUserId(User); // gets the user id from the jwt token
            var request = this.requestsService.ById(id, userId, true)
                .Include(r => r.Requester)
                .Include(r => r.Status)
                .Include(r => r.Category)
                .FirstOrDefault();
            //if (request == null)
            //{
            //    return NotFound();
            //}
            //return Ok(request);
            var result = new RequestDetailsViewModel
            {
                Id = request.Id,
                Subject = request.Subject,
                CreatedOn = request.StartTime.ToShortDateString(),
                Description = request.Description,
                Author = new UserDetailsViewModel
                {
                    FullName = request.Requester.FullName
                },
                Status = request.Status.Name,
                Category = request.Category.Name
            };
            return result;
        }

        [HttpGet]
        public IEnumerable<RequestListingViewModel> Get([FromQuery]TableFilteringModel model)
        {
            string currentUserId = userManager.GetUserId(User);
            bool isTechnician = true; // TODO CHANGE THIS

            // Filter the requests, depending on the criteria in the model
            var requestQueryable = this.requestsService.GetAll(currentUserId, isTechnician, model)
                .Include(r => r.Status)
                .Include(r => r.Requester)
                .ToArray();

            //// Needed for the calculation of the number of pages to be displayed
            //int total = requestQueryable.Count();

            IEnumerable<RequestListingViewModel> requests = requestQueryable
                .Select(r => new RequestListingViewModel
                {
                    Id = r.Id,
                    Subject = r.Subject,
                    Requester = r.Requester.FullName,
                    StartTime = r.StartTime,
                    Status = r.Status.Name
                })
                .ToArray();

            //return Ok(new { requests, total });

            return requests;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(RequestCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string userId = this.userManager.GetUserId(User);

            var request = new Request
            {
                Subject = model.Subject,
                Description = model.Description,
                CategoryId = 1, // TODO CHANGE THIS
                RequesterId = userId,
            };

            await this.requestsService.AddAsync(request);

            await this.requestsService.SaveChangesAsync();

            return CreatedAtAction(nameof(this.PostAsync), model);

        }
    }
}