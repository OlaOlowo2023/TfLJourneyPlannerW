using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TFLTask.Hooks
{
    [Binding]
    public sealed class Browser
    {
        public IWebDriver? Driver;

        private string BaseUrl => TestContext.Parameters["BaseUrl"];

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver?.Dispose();
        }
    }
}