using SEOTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Application.History.Queries
{
    public class RankRecordDto
    {
        public string SearchEngine { get; set; }

        public string Keywords { get; set; }

        public string Url { get; set; }

        public DateTime CheckedDate { get; set; }

        public string Positions { get; set; }
    }
}
