using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SEOTracker.Infrastructure.Services
{
    public interface ISeleninumService
    {
        string ScrapePage(string url);
    }
    public class SeleniumService : ISeleninumService, IDisposable
    {
        private readonly ChromeDriver driver;

        public SeleniumService()
        {
            var options = new ChromeOptions();
            options.AddArguments("headless"); // Run in headless mode without opening a browser window
            options.AddArguments("disable-images");
            options.AddArguments("window-size=1200x600");
            options.AddArguments("--disable-web-security");
            options.AddArguments("--disable-features=SameSiteByDefaultCookies");
            options.AddArguments("--allow-running-insecure-content");
            options.AddArguments("log-level=3");

            driver = new ChromeDriver(options);
        }
        public string ScrapePage(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                // Wait until the page is fully loaded
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                return driver.PageSource;
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine($"An error occurred while scraping the page: {ex.Message}");
                return string.Empty;
            }
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
