using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEOTracker.Application.History.Queries;
namespace SEOTracker.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IMediator _meditor;

        public HistoryController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory(CancellationToken cancellationToken)
        {
            
            var result = await _meditor.Send(new GetRankRecordQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
