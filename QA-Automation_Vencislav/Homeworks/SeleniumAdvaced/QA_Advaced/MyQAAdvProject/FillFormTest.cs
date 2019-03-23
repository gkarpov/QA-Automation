using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Fiature1
//Fiature1_1

namespace MyQAAdvProject
{
    using MyQAAdvProject.Pages;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class FirsSuite
    {
        private IWebDriver _driver;
        private WebDriverWait _waitSecond;
        private WebDriverWait _waitTwoSecond;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }

        [SetUp]
        public void SetUp()
        {
            
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Url = "https://phptravels.org/register.php";
            _waitSecond = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            _waitTwoSecond = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            //may  use mocking
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            //if test fail - screenshot
        }
        [Test]
        public void Test1() 
        {
            
            RegistrationPage regPage = new RegistrationPage(_driver);
            regPage.FillRegistrationForm();

            
            Assert.NotNull(errormsgs.Find(x => x.Text.Equals("The passwords you entered did not match")));
            Assert.Null(errormsgs.Find(x => x.Text.Equals("AThe passwords you entered did not match")));

        }
        private void SafeType(IWebElement element, string text)
        {

            element.Clear();
            element.SendKeys(text);

        }
        
    }
}
