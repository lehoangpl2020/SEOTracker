using MediatR;
using SEOTracker.Core.Enums;

namespace SEOTracker.Application.Trackers.Commands
{
    public class SearchCommand : IRequest<string>
    {
        public SearchEngineType SearchEngine { get; set; }
        public string Keywords { get; set; }
        public string Url { get; set; }
    }
}
