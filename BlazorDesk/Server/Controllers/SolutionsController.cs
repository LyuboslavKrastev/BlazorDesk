using BlazorDesk.AppModels.Management.Binding;
using BlazorDesk.AppModels.View;
using BlazorDesk.Data.Models;
using BlazorDesk.Data.Models.Solution;
using BlazorDesk.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDesk.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SolutionsController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly ISolutionsService solutionsService;
        public SolutionsController(UserManager<User> userManager, ISolutionsService solutionsService)
        {
            this.userManager = userManager;
            this.solutionsService = solutionsService;
        }

        [HttpGet]
        public ActionResult<SolutionListingViewModel> Get()
        {
            try
            {
                IEnumerable<SolutionListingViewModel> solutions = this.solutionsService.GetAll().Select(s => new SolutionListingViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    CreationTime = s.CreationTime.ToShortDateString()
                }).ToArray();

                return Ok(solutions);
            }
            catch (Exception)
            {
                // TODO: Log the exception
                return BadRequest();
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolutionDetailsViewModel>> Get(int id)
        {
            try
            {
                string userId = this.userManager.GetUserId(User); // gets the user id from the jwt token
                var solution =  await this.solutionsService.ByIdAndIncreaseViews(id);

                if (solution == null)
                {
                    return NotFound();
                }

                var result = new SolutionDetailsViewModel
                {
                    Id = solution.Id,
                    Title = solution.Title,
                    CreatedOn = solution.CreationTime.ToShortDateString(),
                    Content = solution.Content,
                    Author = solution.Author.FullName
                };
                return result;
            }
            catch (Exception)
            {
                //TODO: Log the exception
                return BadRequest();
            }           
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(SolutionCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string userId = this.userManager.GetUserId(User);

            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest();
            }

            var solution = new Solution
            {
                Title = model.Title,
                Content = model.Content,
                AuthorId = userId,
            };

            await this.solutionsService.AddAsync(solution);

            //if (model.Attachments != null)
            //{
            //    string path = await fileUploader.CreateAttachmentAsync(model.Subject, model.Attachments, "Requests");

            //    ICollection<RequestAttachment> attachments = new List<RequestAttachment>();

            //    foreach (var attachment in model.Attachments)
            //    {
            //        RequestAttachment requestAttachment = new RequestAttachment
            //        {
            //            FileName = attachment.FileName,
            //            PathToFile = Path.Combine(path, attachment.FileName),
            //            RequestId = request.Id
            //        };
            //        attachments.Add(requestAttachment);
            //    }

            //    await this.attachmentService.AddRangeAsync(attachments);
            //}

            await this.solutionsService.SaveChangesAsync();

            return CreatedAtAction(nameof(this.PostAsync), model);

        }
    }
}