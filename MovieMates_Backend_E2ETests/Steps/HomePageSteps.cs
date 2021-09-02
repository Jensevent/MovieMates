using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace MovieMates_Backend_E2ETests.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver webDriver;

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            this.webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }


        [Then(@"I log in")]
        public void ThenILogIn()
        {
            IWebElement usernameBox = webDriver.FindElement(By.Id("username"));
            IWebElement passwordBox = webDriver.FindElement(By.Id("password"));
            IWebElement submitBtn = webDriver.FindElement(By.Id("login"));

            usernameBox.SendKeys("jensevent");
            passwordBox.SendKeys("Welkom12345");
            submitBtn.Click();
            sleep(3);
        }


        [Then(@"I select genre ""(.*)""")]
        public void ThenISelectAGenre(int genre)
        {
            IWebElement genreElement = webDriver.FindElement(By.Id(genre.ToString()));
            genreElement.Click();
            sleep(3);
        }

        
        [Then(@"I click the like button")]
        public void ThenIClickTheLikeButton()
        {
            IWebElement btn = webDriver.FindElement(By.ClassName("LikeButton"));
            btn.Click();
            sleep(1);

            string alertMessage = webDriver.SwitchTo().Alert().Text;
            Assert.Contains("The user has already saved this movie.", alertMessage);
            
        }


        [Then(@"I click the dislike button")]
        public void ThenIClickTheDislikeButton()
        {
            
            IWebElement btn = webDriver.FindElement(By.ClassName("DislikeButton"));
            btn.Click();
            sleep(3);

            Assert.Contains("Avengers: Endgame", webDriver.PageSource);
        }


        [Then(@"There are no movies available")]
        public void ThenThereAreNoMoviesAvailable()
        {
            Assert.Contains("No movies found with this genre", webDriver.PageSource);
        }


        [Then(@"I log out")]
        public void ThenILogOut()
        {
            IWebElement btn = webDriver.FindElement(By.Id("logout"));
            btn.Click();
            sleep(3);

            Assert.Contains("Login", webDriver.PageSource);
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
    }
}
