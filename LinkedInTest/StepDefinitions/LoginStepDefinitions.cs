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
        public IWebDriver driver;

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
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.linkedin.com/";
        }

        [When(@"User will enter username")]
        public void WhenUserWillEnterUsername()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            
            emailInput.SendKeys("pwd.com");
            
        }

        [When(@"User will enter password")]
        public void WhenUserWillEnterPassword()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            passwordInput.SendKeys("pwd");
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
            Assert.That(driver.Title.Contains("Log In"));
        }
        [Then(@"Error message for Password Length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {

            Assert.That(driver.FindElement(By.XPath("//p[text()='The password you provided must" +
                " have at least 6 characters']")).Text
                .Contains("The password you provided must have at least 6 characters"));
        }

    }
}
