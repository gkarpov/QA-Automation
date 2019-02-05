namespace SeleniumGoogleSearch
{
    using NUnit.Framework;
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Reflection;
    using System.IO;

    [TestFixture]
    public class SeleniumGoogleSearchTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void SearchForSelenium()
        {
            //Arrange
            _driver.Url = "https://google.com";

            //A..

            //Assert
        }
    }
}
