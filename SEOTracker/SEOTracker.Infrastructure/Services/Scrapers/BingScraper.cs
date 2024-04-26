using SEOTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Infrastructure.Services.Scrapers
{
    public class BingScraper : ISearchEngineScraper
    {
        public List<int> FindPositions(string keyWords, string url)
        {
            throw new NotImplementedException();
        }

        public List<int> FindPositions(string keyWords, string url, string targetUrl)
        {
            throw new NotImplementedException();
        }
    }
}
