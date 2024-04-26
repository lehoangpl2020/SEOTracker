using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Core.Entities
{
    public class RankRecord
    {
        public int RankRecordId { get; set; }

        public string SearchEngine { get; set; }

        public string Keywords { get; set; }

        public string Url { get; set; }

        public DateTime CheckedDate { get; set; }

        public List<RankPosition> Positions { get; set; }   
    }
}
