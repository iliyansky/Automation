using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AgileTravelUITests
{
    [TestClass]
    public class FacebookLogin
    {
        [TestMethod]
        [Obsolete]
        public void TestMethod1()
        {
            IWebDriver driver;
            IWebElement element;

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(100000000));
            driver.Navigate().GoToUrl("https://www.facebook.com/");


            element = driver.FindElement(By.Id("email"));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.SendKeys("iliqn_boqnov@abv.bg");
            element = driver.FindElement(By.Id("pass"));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.SendKeys("6831916999");

            element = driver.FindElement(By.Id("loginbutton"));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();

            element = driver.FindElement(By.CssSelector("#u_0_a > div:nth-child(1) :nth-child(1) div a"));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#u_0_a > div:nth-child(1) :nth-child(1) div a")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#u_0_a > div:nth-child(1) :nth-child(1) div a")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#u_0_a > div:nth-child(1) :nth-child(1) div a")));
            element.Click();


            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#u_fetchstream_3_a :nth-child(3) a")));
            driver.FindElement(By.CssSelector("#u_fetchstream_3_a > li:nth-child(3) > a")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("inputtext")));
            element = driver.FindElement(By.ClassName("inputtext"));
            element.SendKeys("Misho Ionchev");

            driver.Navigate().GoToUrl("https://www.facebook.com/mishoionchew");
            System.Threading.Thread.Sleep(5000);
            element = driver.FindElement(By.Id("u_0_1i"));
            element.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("_1mf")));
            element = driver.FindElement(By.ClassName("_1mf"));
            element.SendKeys("I'm sending you automation message !" + Keys.Enter);
            
        }
    }
}
