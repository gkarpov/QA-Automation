namespace SeleniumWebDriverFirstTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class RegisterInDemoQA
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void RegistrateWithValidData()
        {            
            _driver.Url = "http://www.demoqa.com";
            IWebElement registrateButton = _driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = _driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Ventsislav");
            IWebElement lastName = _driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Ivanov");
            IWebElement matrialStatus = _driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = _driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = _driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = _driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = _driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = _driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = _driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = _driver.FindElement(By.Id("username"));
            //You need to change this for every test
            Type(userName, "BatmanForever");
            IWebElement email = _driver.FindElement(By.Id("email_1"));
            //You need to change this for every test
            Type(email, "Ivanov8@abv.bg");
            IWebElement uploadPicButton = _driver.FindElement(By.Id("profile_pic_10"));
            uploadPicButton.Click();
            _driver.SwitchTo().ActiveElement().SendKeys(Path.GetFullPath(@"..\..\..\logo.jpg"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            IWebElement description = wait.Until(d => d.FindElement(By.Id("description")));
            Type(description, "I think I'm Ready with this test!");
            IWebElement password = _driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = _driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");
            IWebElement submitButton = _driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();
            IWebElement registrationMessage = _driver.FindElement(By.ClassName("piereg_message"));

            Assert.IsTrue(registrateButton.Displayed);
            Assert.AreEqual("Thank you for your registration", registrationMessage.Text);
            StringAssert.Contains("Thank you", registrateButton.Text);            
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
