using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SEOTracker.Application.History.Queries;
using SEOTracker.Application.Trackers.Commands;
namespace SEOTracker.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly IMediator _meditor;
        private readonly SearchEngineSettings _settings;

        public TrackerController(IOptions<SearchEngineSettings> options, IMediator meditor)
        {
            _meditor = meditor;
            _settings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchCommand searchCommand, CancellationToken cancellationToken)
        {
            searchCommand.SearchEngine = _settings.SearchEngine;
            var result = await _meditor.Send(searchCommand, cancellationToken);
            return Ok(result);
        }
    }
}
