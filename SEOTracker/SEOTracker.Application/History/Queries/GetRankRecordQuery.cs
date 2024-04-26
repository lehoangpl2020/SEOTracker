using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Application.History.Queries
{
    public class GetRankRecordQuery : IRequest<List<RankRecordDto>>
    {
    }
}
