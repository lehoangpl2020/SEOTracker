using HtmlAgilityPack;
using SEOTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Infrastructure.Services.Scrapers
{
    public class GoogleScraper : ISearchEngineScraper
    {
        private readonly ISeleninumService _seleniumSerice;

        public GoogleScraper(ISeleninumService seleniumSerice)
        {
            _seleniumSerice = seleniumSerice;
        }

        public List<int> FindPositions(string keyWords, string url)
        {
            var goggleUrl = $"https://www.google.co.uk/search?num=100&q={Uri.EscapeDataString(keyWords)}";

            var pageContent = _seleniumSerice.ScrapePage(goggleUrl);
            var doc = new HtmlDocument();
            doc.LoadHtml(pageContent);
            var nodes = doc.DocumentNode.SelectNodes("//a[@jsname='UWckNb']");

            var positions = new List<int>();
            int position = 1;

            foreach (var node in nodes)
            {
                if (node.Attributes["href"].Value.Contains(url))
                {
                    positions.Add(position);
                }
                position++;
            }

            return positions;
        }
    }


}
