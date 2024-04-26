using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Core.Entities
{
    public class RankPosition
    {
        public int RankPositionId { get; set; }

        public int Position { get; set; }
        public int RankRecordId { get; set; }
        public RankRecord RankRecord { get; set; }
    }
}
