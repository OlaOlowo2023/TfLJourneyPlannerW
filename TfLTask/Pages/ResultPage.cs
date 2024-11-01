using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TFLTask.Hooks;

namespace TFLTask.Pages
{
    public class ResultPage
    {
        public Browser BrowserContext;
        public WebDriverWait Wait => new(BrowserContext.Driver, TimeSpan.FromSeconds(30));
        private Actions Action => new(BrowserContext.Driver);

        public ResultPage(Browser context)
        {
            BrowserContext = context;
        }

        private IWebElement ResultPageHeadline => BrowserContext.Driver.FindElement(By.ClassName("jp-results-headline"));
        private IWebElement CyclingTime => BrowserContext.Driver.FindElement(By.CssSelector("a.journey-box.cycling .col2.journey-info"));
        private IWebElement WalkingTime => BrowserContext.Driver.FindElement(By.CssSelector("a.journey-box.walking .col2.journey-info"));
        private IWebElement EditPreference => BrowserContext.Driver.FindElement(By.CssSelector("button.toggle-options.more-options"));
        private IWebElement LeastWalking => BrowserContext.Driver.FindElement(By.XPath("//*[@for='JourneyPreference_2']"));
        private IWebElement JourneyButton => BrowserContext.Driver.FindElement(By.CssSelector("#more-journey-options input.primary-button.plan-journey-button"));
        private IWebElement PublicTransportTab => BrowserContext.Driver.FindElement(By.Id("publictransport"));
        private IWebElement JourneyTime => BrowserContext.Driver.FindElement(By.CssSelector("#option-1-heading .journey-time.no-map"));
        private IWebElement ViewDetails => BrowserContext.Driver.FindElement(By.CssSelector("#option-1-content button.secondary-button.show-detailed-results.view-hide-details"));
        private IWebElement ValidationError => BrowserContext.Driver.FindElement(By.CssSelector("li.field-validation-error"));

        public bool UpStairs => BrowserContext.Driver.FindElement(By.CssSelector("#option-1-content a.up-stairs.tooltip-container")).Displayed;
        public bool UpLift => BrowserContext.Driver.FindElement(By.CssSelector("#option-1-content a.up-lift.tooltip-container")).Displayed;
        public bool LevelWalkway => BrowserContext.Driver.FindElement(By.CssSelector("#option-1-content a.level-walkway.tooltip-container")).Displayed;
        
        public string ReturnJourneyTime()
        {
            Wait.Until(d => JourneyTime.Displayed);
            return JourneyTime.Text;
        }
        public string ResultPageHeadlineText()
        {
            Wait.Until(d => ResultPageHeadline.Displayed);
            return ResultPageHeadline.Text;
        }

        public string ReturnCyclingTime()
        {
            Wait.Until(d => CyclingTime.Displayed);
            return CyclingTime.Text;
        }

        public string ReturnWalkingTime()
        {
            Wait.Until(d => WalkingTime.Displayed);
            return WalkingTime.Text;
        }
        
        private void UpdateJourneyButton()
        {
            Wait.Until(d => JourneyButton.Displayed);
            Action.MoveToElement(JourneyButton);
            JourneyButton.Click();
        }

        private void ClickToExpandEditPreference()
        {
            Wait.Until(d => EditPreference.Displayed);
            Action.MoveToElement(EditPreference);
            EditPreference.Click();
            Wait.Until(d => PublicTransportTab.Displayed);
        }

        private void SelectLeastWalking()
        {
            Wait.Until(d => LeastWalking.Displayed);
            Action.MoveToElement(LeastWalking);
            LeastWalking.Click();            
        }

        public void UpdatePreferenceToLeastWalking()
        {
            ClickToExpandEditPreference();
            SelectLeastWalking();
            UpdateJourneyButton();
        }

        public void ClickViewDetails()
        {
            Wait.Until(d => ViewDetails.Displayed);
            Action.MoveToElement(ViewDetails);
            ViewDetails.Click();
        }

        public string ValidationErrorText()
        {
            Wait.Until(d => ValidationError.Displayed);
            return ValidationError.Text;
        }
    }
}
