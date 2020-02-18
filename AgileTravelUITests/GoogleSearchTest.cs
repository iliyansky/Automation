using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace AgileTravelUITests
{
    [TestClass]
    public class GoogleSearchTest
    {

        [TestMethod]
        [Obsolete]
        public void SearchJobsInMilestoneBulgaria()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver driver;
            IWebElement element;

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Navigate().GoToUrl("https://www.milestonesys.com/");

            element = driver.FindElement(By.CssSelector("a:last-child"));
            element.Click();

            element = driver.FindElement(By.PartialLinkText("jobs"));
            element.Click();
            System.Threading.Thread.Sleep(2000);

            element = driver.FindElement(By.CssSelector("#join-milestone-team-container .milestone-job-list label:nth-child(1) select"));
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue("IT");

            element = driver.FindElement(By.CssSelector("#join-milestone-team-container .milestone-job-list label:nth-child(2) select"));
            selectElement = new SelectElement(element);
            selectElement.SelectByValue("Sofia - Bulgaria");

            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();

            Assert.IsNotNull(driver.FindElement(By.Id("job-list")));

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("ssJobs.pdf", ScreenshotImageFormat.Jpeg);

            driver.Quit();
        }

        [TestMethod]
        public void SelectVideoFromYouTubeAndPauseIt()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://youtube.com");

            IWebElement element = driver.FindElement(By.Id("search"));
            element.SendKeys("riles");
            driver.FindElement(By.Id("search-icon-legacy")).Click();

            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.CssSelector("[title~='PESETAS']")).Click();

            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.CssSelector("#movie_player > div.ytp-chrome-bottom > div.ytp-chrome-controls > div.ytp-left-controls > button")).Click();
        }
    }
}
