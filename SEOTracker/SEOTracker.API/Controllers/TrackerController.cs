using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEOTracker.Application.History.Queries;
using SEOTracker.Application.Trackers.Commands;
namespace SEOTracker.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly IMediator _meditor;

        public TrackerController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchCommand searchCommand, CancellationToken cancellationToken)
        {
            var result = await _meditor.Send(searchCommand, cancellationToken);
            return Ok(result);
        }
    }
}
