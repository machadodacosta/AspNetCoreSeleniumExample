using Exemplo.AspNetCoreSelenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using Xunit;

namespace Exemplo.AspNetCoreSelenium
{
    public class GooglePageExampleTest
    {
        /// <summary>
        /// Access the site https://www.seleniumhq.org/download/ to get the other drivers
        /// </summary>
        private readonly string driverDirectory = "\\Drivers";
        private readonly bool isHeadless = false;
        private readonly Browser browser = Browser.Chrome;

        private readonly string url = "https://www.google.com";

        [Fact(DisplayName = "Search by Selenium on Google web site.")]
        public void SearchForSeleniumInGooglePage()
        {
            IWebDriver driver = GetDriver();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            IWebElement searchText = driver.FindElement(By.Name("q"));
            searchText.SendKeys("Selenium");

            IWebElement buttonClick = driver.FindElement(By.Name("btnK"));
            buttonClick.Submit();

            IWebElement foundLink = driver.FindElement(By.PartialLinkText("Selenium - Web Browser Automation"));

            Assert.NotNull(foundLink);

            driver.Close();
        }

        protected RemoteWebDriver GetDriver()
        {
            if (browser == Browser.Chrome)
            {
                return GetChromeDriver();
            }

            return new InternetExplorerDriver(driverDirectory);
        }

        private RemoteWebDriver GetChromeDriver()
        {
            if (isHeadless)
            {
                var driverOptions = new ChromeOptions();
                driverOptions.AddArgument("--headless");
                return new ChromeDriver(driverDirectory, driverOptions);
            }

            return new ChromeDriver(driverDirectory);
        }
    }
}
