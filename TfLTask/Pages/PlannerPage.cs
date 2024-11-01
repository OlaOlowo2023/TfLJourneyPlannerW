using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TFLTask.Hooks;

namespace TFLTask.Pages
{
    public class PlannerPage
    {
        public Browser BrowserContext;
        public WebDriverWait Wait => new(BrowserContext.Driver, TimeSpan.FromSeconds(60));

        public PlannerPage(Browser context)
        {
            BrowserContext = context;
        }

        private IWebElement Cookie => BrowserContext.Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement InputFrom => BrowserContext.Driver.FindElement(By.Id("InputFrom"));
        private IWebElement InputFromErrorMessage => BrowserContext.Driver.FindElement(By.Id("InputFrom-error"));
        private IWebElement InputTo => BrowserContext.Driver.FindElement(By.Id("InputTo"));
        private IWebElement InputToErrorMessage => BrowserContext.Driver.FindElement(By.Id("InputTo-error"));
        private IWebElement PlanJourneyButton => BrowserContext.Driver.FindElement(By.Id("plan-journey-button"));
        private IWebElement AutoCompleteResultFrom => BrowserContext.Driver.FindElement(By.Id("InputFrom-dropdown"));
        private IWebElement AutoCompleteResultTo => BrowserContext.Driver.FindElement(By.Id("InputTo-dropdown"));
        private string PlannerPageHeadline => BrowserContext.Driver.FindElement(By.ClassName("hero-headline")).Text;

        public string PlannerPageHeadlineText()
        {
            AcceptCookies();
            return PlannerPageHeadline;
        }

        public void JorneyPlanner(string from, string to)
        {   
            InputFrom.SendKeys(from);
            Wait.Until(d => AutoCompleteResultFrom.Displayed);
            InputFrom.SendKeys(Keys.ArrowDown);
            InputFrom.SendKeys(Keys.Enter);
            
            InputTo.SendKeys(to);
            Wait.Until(d => AutoCompleteResultTo.Displayed);
            InputTo.SendKeys(Keys.ArrowDown);
            InputTo.SendKeys(Keys.Enter);

            Wait.Until(d => PlanJourneyButton.Displayed);
            PlanJourneyButton.Click();
        }

        private void AcceptCookies()
        {
           Wait.Until(d => Cookie.Displayed);
           Cookie.Click();
        }   
        
        public void InvalidJourney(string inputFrom, string inputTo)
        {
            InputFrom.SendKeys(inputFrom);
            InputTo.SendKeys(inputTo);
            PlanJourneyButton.Click();
        }

        public void EnterNoLocations()
        {
            InputFrom.SendKeys(" ");
            PlanJourneyButton.Click();
        }

        public string InputFromErrorMessaageText()
        {
            Wait.Until(d => InputFromErrorMessage.Displayed);
            return InputFromErrorMessage.Text;
        }

        public string InputToErrorMessaageText()
        {
            Wait.Until(d => InputToErrorMessage.Displayed);
            return InputToErrorMessage.Text;
        }
    }
}
