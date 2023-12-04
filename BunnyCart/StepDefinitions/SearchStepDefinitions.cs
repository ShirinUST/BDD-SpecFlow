using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions:CoreCodes
    {
        public static IWebDriver? driver;
        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();

        }

        [Given(@"User will be on the HomePage")]
        public void GivenUserWillBeOnTheHomePage()
        {
            driver.Url = "https://www.bunnycart.com/";
        }

        [AfterFeature]
        public static void CleanupBrowser()
        {
            driver?.Quit();
        }

        [When(@"User will type the '([^']*)' in the searchbox")]
        public void WhenUserWillTypeTheInTheSearchbox(string searchtext)
        {
            IWebElement? searchInput = driver.FindElement(By.Id("search"));
            searchInput.SendKeys(searchtext);
        }

        [When(@"User clicks on search button")]
        public void WhenUserClicksOnSearchButton()
        {
            IWebElement? searchButton = driver.FindElement(By.XPath("//button[span[text()='Search']]"));
            searchButton.Click();
        }

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            Assert.That(driver.Url.Contains(searchtext));
        }
    }
}
