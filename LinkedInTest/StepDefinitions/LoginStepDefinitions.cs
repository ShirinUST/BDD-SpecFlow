using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkedInTest.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        public static IWebDriver driver;
        public IWebElement PasswordInput;

        //[BeforeScenario]
        //public void InitializeBrowser()
        //{
        //    driver = new ChromeDriver();

        //}
        //[AfterScenario]
        //public void CleanupBrowser()
        //{
        //    driver?.Quit();
        //}
        [BeforeFeature]
        public static void InitializeBrowser()
        {
           driver = new ChromeDriver();

        }
        [BeforeScenario]
        public static void LoadURL()
        {
            driver.Url = "https://www.linkedin.com/";
        }

        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://www.linkedin.com/";
        }
        [AfterFeature]
        public static void CleanupBrowser()
        {
            driver?.Quit();
        }

        [When(@"User will enter username '(.*)'")]
        public void WhenUserWillEnterUsername(string un)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));

            emailInput.SendKeys(un);

        }

        [When(@"User will enter password '(.*)'")]
        public void WhenUserWillEnterPassword(string pwd)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            PasswordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            PasswordInput.SendKeys(pwd);
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type='submit']")));

            Thread.Sleep(3000);

            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to home page")]
        public void ThenUserWillBeRedirectedToHomePage()
        {
            Assert.That(driver.Title.Contains("Security"));
        }
        [Then(@"Error message for Password Length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {

            Assert.That(driver.FindElement(By.XPath("//p[text()='The password you provided must" +
                " have at least 6 characters']")).Text
                .Contains("The password you provided must have at least 6 characters"));
        }

        [When(@"User will click show link on Password box")]
        public void WhenUserWillClickShowLink()
        {
            IWebElement showLinkElement = driver.FindElement(By.XPath("//button[text()='Show']"));
            showLinkElement.Click();
        }

        [Then(@"Password should be visible to user")]
        public void ThenPasswordShouldBeVisibleToUser()
        {
            Assert.That(PasswordInput.GetAttribute("type").Equals("text"));
        }

        [When(@"User will click hide link on Password box")]
        public void WhenUserWillClickHideLinkOnPasswordBox()
        {
            IWebElement hideLinkElement = driver.FindElement(By.XPath("//button[text()='Hide']"));
            hideLinkElement.Click();
        }

        [Then(@"Password should be hide to user")]
        public void ThenPasswordShouldBeHideToUser()
        {
            Assert.That(PasswordInput.GetAttribute("type").Equals("password"));
        }


    }
}
