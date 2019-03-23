namespace SeleniumWebDriverFirstTests
{
    using NPOI.SS.UserModel;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SeleniumWebDriverFirstTests.Factories;
    using SeleniumWebDriverFirstTests.Models;
    using SeleniumWebDriverFirstTests.Pages.DraggablePage;
    using SeleniumWebDriverFirstTests.Pages.RegistrationPage;
    using SeleniumWebDriverFirstTests.Pages.SideBarPage;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class RegisterInDemoQAChrome
    {
        private IWebDriver _driver;
        private DraggablePage _draggablePage;
        private SideBarPage _sideBarPage;
        private RegistrationPage _regPage;
        private RegistrationUser _user;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _draggablePage = new DraggablePage(_driver);
            _sideBarPage = new SideBarPage(_driver);
            _regPage = new RegistrationPage(_driver);
            _user = UserFactory.GenerateRegUser();
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
            using (var file = new FileStream(Path.GetFullPath(@"..\..\..\demo.xlsx"), FileMode.Open))
            {
                IWorkbook workbook = WorkbookFactory.Create(file);
                ISheet sheet = workbook.GetSheet("DemoSheet");
                
                for (int i = 1; i < 4; i++)
                {
                    IRow row = sheet.GetRow(i);
                    var person = new DemoExcel();
                    person.Name = row.GetCell(0).StringCellValue;
                    person.Age = row.GetCell(1).StringCellValue;
                    person.JobTitle = row.GetCell(2).StringCellValue;
                }

            }






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
            _regPage.FillRegistrationForm(_user);

            //Assert
            Assert.IsTrue(_regPage.RegistrationMessage.Displayed);
            StringAssert.Contains("Thank you", _regPage.RegistrationMessage.Text);
        }

        [Test]
        [TestCase("Ventsi", "")]
        [TestCase("", "")]
        public void RegistrateWithoutNameShouldShowErrorMeseage(string firstName, string lastName)
        {
            _regPage.NavigateTo();
            _user.FirstName = firstName;
            _user.LastName = lastName;

            _regPage.FillRegistrationForm(_user);

            var logs = _driver.Manage().Logs.GetLog(LogType.Browser);

            Assert.IsTrue(_regPage.NameErrorMessage.Displayed);
            Assert.AreEqual("* This field is required", _regPage.NameErrorMessage.Text);
        }

        [Test]
        public void RegistrateWithoutPhoneNumber()
        {
            _regPage.NavigateTo();
            _user.Phone = "";

            _regPage.FillRegistrationForm(_user);

            Assert.IsTrue(_regPage.PhoneErrorMessage.Displayed);
            Assert.AreEqual("* This field is required", _regPage.PhoneErrorMessage.Text);
        }

        [Test]
        public void DragElementByPixels()
        {
            _draggablePage.NavigateTo();

            Thread.Sleep(2000);

            _draggablePage.DragObjectByPixels();

            Thread.Sleep(5000);
        }

        [Test]
        public void DragElementToElement()
        {
            _draggablePage.NavigateTo();
            _sideBarPage.DropableButton.Click();

            _draggablePage.DragObjectToTarget();

            string background = _draggablePage.DropableTargetAfterAction.GetCssValue("background");
            string[] hexColor = background.Split(')', StringSplitOptions.RemoveEmptyEntries);
           
            int color = Convert.ToInt32(hexColor[0], 16);
            //#fbf9ee
        }
    }
}