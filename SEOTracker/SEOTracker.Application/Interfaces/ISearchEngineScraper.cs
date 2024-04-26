using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Application.Interfaces
{
    public interface ISearchEngineScraper
    {
        List<int> FindPositions(string keyWords, string url);
    }
}
