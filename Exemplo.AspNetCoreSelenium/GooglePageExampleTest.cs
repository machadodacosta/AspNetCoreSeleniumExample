using Exemplo.AspNetCoreSelenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Xunit;

namespace Exemplo.AspNetCoreSelenium
{
    public class GooglePageExampleTest
    {
        /// <summary>
        /// Access the site https://www.seleniumhq.org/download/ to get the other drivers
        /// </summary>
        private readonly string driverDirectory = "\\Drivers";
        private readonly bool openBrowser = true;
        private readonly Browser browser = Browser.Chrome;

        private readonly string url = "https://www.google.com";

        [Fact]
        public void SearchForSeleniumInGooglePage()
        {
            IWebDriver driver = GetDriver();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            IWebElement searchText = driver.FindElement(By.Name("q"));
            searchText.SendKeys("Selenium");

            IWebElement buttonClick = driver.FindElement(By.Name("btnK"));
            buttonClick.Submit();
        }

        protected OpenQA.Selenium.Remote.RemoteWebDriver GetDriver()
        {
            if (browser == Browser.Chrome)
            {
                var driverOptions = new ChromeOptions();
                if (openBrowser)
                {
                    (driverOptions as ChromeOptions).AddArgument("--headless");
                }

                return new ChromeDriver(driverDirectory, driverOptions);
            }

            //headless doesn't work for Internet Explorer
            return new InternetExplorerDriver(driverDirectory);
        }
    }
}
