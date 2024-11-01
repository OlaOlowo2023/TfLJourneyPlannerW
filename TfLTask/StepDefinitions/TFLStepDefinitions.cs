using NUnit.Framework;
using NUnit.Framework.Legacy;
using TFLTask.Pages;

namespace TFLTask.StepDefinitions
{
    [Binding]
    public class TFLStepDefinitions
    {
        private readonly PlannerPage _plannerPage;
        private readonly ResultPage _resultPage;

        public TFLStepDefinitions(PlannerPage plannerPage, ResultPage resultPage)
        {
            _plannerPage = plannerPage;
            _resultPage = resultPage;
        }

        [Given(@"customer is on plan a journey planner widget via TfL website")]
        public void GivenCustomerIsOnPlanAJourneyPlannerWidgetViaTfLWebsite()
        {
            Assert.That(_plannerPage.PlannerPageHeadlineText, Is.EqualTo("Plan a journey"));
        }

        [Given(@"customer is on plan a journey widget")]
        public void GivenCustomerIsOnPlanAJourneyWidget()
        {
            Assert.That(_plannerPage.PlannerPageHeadlineText, Is.EqualTo("Plan a journey"));
        }

        [When(@"customer plans a journey from '([^']*)' to '([^']*)'")]
        public void WhenCustomerInputsAJourneyFromTo(string fromJourney, string toJourney)
        {
            _plannerPage.JorneyPlanner(fromJourney, toJourney);
        }

        [Then(@"the result page should display cycling time as '([^']*)' and walking time as '([^']*)'")]
        public void ThenTheResultPageShouldDisplayCyclingTimeAsAndWalkingTimeAs(string cyclingTime, string walkingTime)
        {
            Assert.That(_resultPage.ResultPageHeadlineText, Is.EqualTo("Journey results"));
            Assert.That(_resultPage.ReturnCyclingTime, Is.EqualTo(cyclingTime));
            Assert.That(_resultPage.ReturnWalkingTime, Is.EqualTo(walkingTime));
        }

        [Given(@"customer has planned a journey from '([^']*)' to '([^']*)'")]
        public void GivenCustomerHasPlannedAJourneyFromTo(string fromJourney, string toJourney)
        {
            Assert.That(_plannerPage.PlannerPageHeadlineText, Is.EqualTo("Plan a journey"));
            _plannerPage.JorneyPlanner(fromJourney, toJourney);
            Assert.That(_resultPage.ResultPageHeadlineText, Is.EqualTo("Journey results"));
        }

        [When(@"customer updates journey to routes with least walking")]
        public void WhenCustomerUpdatesJourneyToRoutesWithLeastWalking()
        {
            _resultPage.UpdatePreferenceToLeastWalking();
        }

        [Then(@"the result page should display journey time as '([^']*)'")]
        public void ThenTheResultPageShouldDisplayJourneyTimeAs(string journeyTime)
        {
            Assert.That(_resultPage.ResultPageHeadlineText, Is.EqualTo("Journey results"));
            StringAssert.Contains(journeyTime, _resultPage.ReturnJourneyTime());
        }

        [Given(@"customer has updated routes with least walking between '([^']*)' and '([^']*)'")]
        public void GivenCustomerHasUpdatedRoutesWithLeastWalkingBetweenAnd(string fromJourney, string toJourney)
        {
            Assert.That(_plannerPage.PlannerPageHeadlineText, Is.EqualTo("Plan a journey"));
            _plannerPage.JorneyPlanner(fromJourney, toJourney);
            Assert.That(_resultPage.ResultPageHeadlineText, Is.EqualTo("Journey results"));
            _resultPage.UpdatePreferenceToLeastWalking();
        }

        [When(@"customer clicks on view details button")]
        public void WhenCustomerClicksOnViewDetailsButton()
        {
            _resultPage.ClickViewDetails();            
        }

        [Then(@"access information should display")]
        public void ThenAccessInformationShouldDisplay()
        {
            Assert.That(_resultPage.UpStairs, Is.True);
            Assert.That(_resultPage.UpLift, Is.True);
            Assert.That(_resultPage.LevelWalkway, Is.True);
        }

        [When(@"customer plans an invalid journey")]
        public void WhenCustomerPlansAnInvalidJourney()
        {
            _plannerPage.InvalidJourney("1234567890", "0987654321");
        }

        [Then(@"error message should be displayed on journey results page as ""([^""]*)""")]
        public void ThenErrorMessageShouldBeDisplayedOnJourneyResultsPageAs(string errorMessage)
        {
            StringAssert.AreEqualIgnoringCase(_resultPage.ValidationErrorText(), errorMessage);
        }

        [When(@"customer enters no locations")]
        public void WhenCustomerEntersNoLocations()
        {
            _plannerPage.EnterNoLocations();
        }

        [Then(@"error message should be displayed for from field as '([^']*)'")]
        public void ThenErrorMessageShouldBeDisplayedForFromFieldAs(string errorMessage)
        {
            StringAssert.AreEqualIgnoringCase(_plannerPage.InputFromErrorMessaageText(), errorMessage);
        }

        [Then(@"error message should be displayed for to field as '([^']*)'")]
        public void ThenErrorMessageShouldBeDisplayedForToFieldAs(string errorMessage)
        {
            StringAssert.AreEqualIgnoringCase(_plannerPage.InputToErrorMessaageText(), errorMessage);
        }
    }
}
