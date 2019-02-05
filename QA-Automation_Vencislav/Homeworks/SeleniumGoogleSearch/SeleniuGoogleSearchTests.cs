namespace SeleniumGoogleSearch
{
    using NUnit.Framework;
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Reflection;
    using System.IO;
    using OpenQA.Selenium.Interactions;

    [TestFixture]
    public class SeleniumGoogleSearchTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }


        [Test]
        public void SearchForSelenium()
        {
            //Arrange + Act
            _driver.Url = "https://google.com";

            //Navigate to Search field
            IWebElement searchfield = _driver.FindElement(By.Name("q"));

            //Type text to search and tap Enter
            searchfield.SendKeys("Selenium");
            searchfield.SendKeys(Keys.Enter);

            //Navigate to Search result with Official Selenium web site
            IWebElement link = _driver.FindElement(By.PartialLinkText("Selenium - Web Browser Automation"));
            link.Click();

            //Assert Title of official web sute
            Assert.AreEqual("Selenium - Web Browser Automation", _driver.Title);
        }

        [Test]
        public void SearchForQACourse()
        {
            //Arrange + Act
            _driver.Url = "https://softuni.bg";

            //Search for QA Automation Link in recent courses
            Boolean isPresent;
            IWebElement next = _driver.FindElement(By.ClassName("slick-next"));
            Actions actions = new Actions(_driver);
            actions.MoveToElement(next);
            actions.Perform();

            isPresent = _driver.FindElements(By.PartialLinkText("QA Automation")).Count > 0;
            while (!isPresent)
            {
                next.Click();
                isPresent = _driver.FindElements(By.PartialLinkText("QA Automation")).Count > 0;
            }

            _driver.FindElement(By.PartialLinkText("QA Automation")).Click();

            
            
            Assert.Multiple(() =>
            {
                //Assert Title of official web sute
                Assert.AreEqual("Курс QA Automation - януари 2019 - Софтуерен университет", _driver.Title);
                //Assert there are some tags with tis title >= 2//Assert there are some tags with tis title >= 2
                Assert.IsTrue(_driver.FindElements(By.LinkText("QA Automation")).Count>0);
            });
            
        }

        //[Test]
        //public void 




        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
