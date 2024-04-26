using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Application.Trackers.Commands
{
    public class SearchCommand : IRequest<string>
    {
       // public string SearchEngine { get; set; }
        public string Keywords { get; set; }
        public string Url { get; set; }
    }
}
