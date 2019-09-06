using BlazorDesk.AppModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDesk.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestsController : ControllerBase
    {
        [HttpGet]
        public Request Get()
        {
            var request = new Request
            {
                Id = 1,
                Subject = "Subject 1",
                Description = "Description!"
            };
            return request;
        }
    }
}