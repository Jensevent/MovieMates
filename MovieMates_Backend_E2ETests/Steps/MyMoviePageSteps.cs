using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace MovieMates_Backend_E2ETests.Steps
{
    [Binding]
    public class MyMoviePageSteps
    {
        private readonly IWebDriver webDriver;

        public MyMoviePageSteps(ScenarioContext scenarioContext)
        {
            this.webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        private void sleep(int seconds)
        {
            DateTime now = DateTime.Now;

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromSeconds(seconds) > TimeSpan.Zero);
        }


        [Then(@"I navigate to ""(.*)""")]
        public void ThenINavigateTo(string page)
        {
            webDriver.Url = $"{page}";
            sleep(3);
        }
        
        [Then(@"I mark a movie as watched")]
        public void ThenIMarkAMovieAsWatched()
        {
            IWebElement btn = webDriver.FindElement(By.Id("WatchMovie"));
            btn.Click();

            bool test = false;
            if (webDriver.FindElement(By.Id("WatchedMovie")) != null)
            {
                test = true;
            }

            Assert.True(test);
        }
    }
}
