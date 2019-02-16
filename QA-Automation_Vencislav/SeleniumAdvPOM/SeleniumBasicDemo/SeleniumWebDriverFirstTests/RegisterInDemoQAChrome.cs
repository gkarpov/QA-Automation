namespace SeleniumWebDriverFirstTests
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using SeleniumWebDriverFirstTests.Pages.DraggablePage;
    using SeleniumWebDriverFirstTests.Pages.RegistrationPage;
    using SeleniumWebDriverFirstTests.Pages.SideBarPage;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class RegisterInDemoQAChrome
    {
        private IWebDriver _driver;
        private DraggablePage _draggablePage;
        private SideBarPage _sideBarPage;
        private RegistrationPage _regPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
           _draggablePage = new DraggablePage(_driver);
            _sideBarPage = new SideBarPage(_driver);
            _regPage = new RegistrationPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile("d:" + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
            }

            _driver.Quit();
        }

        [Test]
        public void NavigateToregistrationPage()
        {
            _sideBarPage.RegistrationButton.Click();

            Assert.IsTrue(_regPage.HeaderMessage.Displayed);
            StringAssert.Contains("Registration", _regPage.HeaderMessage.Text);
        }

        [Test]
        public void RegistrateWithValidData()
        {
            //Arrange
            _regPage.NavigateTo();

            //Act
            _regPage.FillRegistrationForm();

            //Assert
            Assert.IsTrue(_regPage.RegistrationMessage.Displayed);
            StringAssert.Contains("Thank you", _regPage.RegistrationMessage.Text);
        }

        [Test]
        public void RegistrateWithoutName()
        {
            _regPage.NavigateTo();
            _regPage.FillRegistrationForm();

            Assert.IsTrue(_regPage.NameErrorMessage.Displayed);
            Assert.AreEqual("* This field is required", _regPage.NameErrorMessage.Text);
        }

        [Test]
        public void RegistrateWithoutPhoneNumber()
        {
            _regPage.NavigateTo();
            _regPage.FillRegistrationForm();

            Assert.IsTrue(_regPage.PhoneErrorMessage.Displayed);
            Assert.AreEqual("* This field is required", _regPage.PhoneErrorMessage.Text);
        }
    }
}