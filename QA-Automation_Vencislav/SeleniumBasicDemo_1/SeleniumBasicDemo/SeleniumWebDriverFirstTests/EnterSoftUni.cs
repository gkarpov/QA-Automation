namespace SeleniumWebDriverFirstTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class EnterSoftUni
    {
        [Test]
        public void NavigateToSoftUni()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "http://softuni.bg";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement loginButton = wait.Until<IWebElement>((w) =>
            {
                return w.FindElement(By.LinkText("Вход"));
            });
            loginButton.Click();
            IWebElement userName = driver.FindElement(By.Name("username"));
            userName.Clear();
            //TODO: Add valid username
            userName.SendKeys("*********");
            IWebElement password = driver.FindElement(By.Name("password"));
            password.Clear();
            //TODO: Add valid password
            password.SendKeys("***********");
            IWebElement login = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div[2]/div[1]/form/input[2]"));
            login.Click();
            IWebElement logo = driver.FindElement(By.XPath("//*[@id=\"page-header\"]/div[1]/div/div/div[1]/a/img[1]"));

            Assert.IsNotNull(logo);
        }
    }
}