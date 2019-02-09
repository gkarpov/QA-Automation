using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQAAdvProject
{
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
            //Arange
            IWebElement firstName = _driver.FindElement(By.Id("inputFirstName"));
            IWebElement lastName = _driver.FindElement(By.Id("inputLastName"));
            IWebElement emailAdr = _driver.FindElement(By.Id("inputEmail"));

            IWebElement countrycode= _driver.FindElement(By.XPath("//*[@id=\"containerNewUserSignup\"]/div[2]/div[4]/div/div/div"));
            IWebElement phone = _driver.FindElement(By.Id("inputPhone"));
            IWebElement company = _driver.FindElement(By.Id("inputCompanyName"));
            IWebElement addr1 = _driver.FindElement(By.Id("inputAddress1"));
            IWebElement addr2 = _driver.FindElement(By.Id("inputAddress2"));

            IWebElement city = _driver.FindElement(By.Id("inputCity"));
            IWebElement state= _driver.FindElement(By.Id("stateinput"));
            IWebElement postcode= _driver.FindElement(By.Id("inputPostcode"));

            SelectElement country = new SelectElement(_driver.FindElement(By.Id("inputCountry")));

            IWebElement taxid = _driver.FindElement(By.Id("inputTaxId"));

            SelectElement customfield1 = new SelectElement(_driver.FindElement(By.Id("customfield1")));
            IWebElement mobile = _driver.FindElement(By.Id("customfield2"));

            IWebElement password1 = _driver.FindElement(By.Id("inputNewPassword1"));
            IWebElement password2 = _driver.FindElement(By.Id("inputNewPassword2"));

            //IWebElement mailing = _driver.FindElement(By.PartialLinkText("bootstrap-switch"));
            IWebElement mailing = _driver.FindElement(By.XPath("//*[@id=\"frmCheckout\"]/div[3]/div/div/span[3]"));

            //IWebElement captcha = _driver.FindElement(By.XPath("//*[@id=\"recaptcha - anchor\"]/div[5]"));

            //IWebElement submit = _driver.FindElement(By.PartialLinkText("btn-recaptcha"));
            IWebElement submit = _driver.FindElement(By.XPath("//*[@id=\"frmCheckout\"]/p/input"));

            //IWebElement error = _driver.FindElement(By.XPath("//*[@id=\"main - body\"]/div/div/div[3]/div[1]/ul"));

            
                

            //Act
            SafeType(firstName, "Ivan");
            SafeType(lastName, "Ivanov");
            SafeType(emailAdr, "ivanov@abv.gd");

            SafeType(phone, "00223344");
            SafeType(company, "Adidas");
            
            SafeType(addr1, "Centralna str. 33");
            
            SafeType(city, "Himkovo");
            SafeType(state, "Stolica");
            SafeType(postcode, "1212");

            country.SelectByText("Bulgaria");

            SafeType(taxid, "1212");

            customfield1.SelectByText("Google");
                
            //IWebElement mobile = _driver.FindElement(By.Id("customfield2"));

            SafeType(password1, "121212");
            SafeType(password2, "121213");


            mailing.Click();

            submit.Click();



            //Assert
            
            
            
            IWebElement error = _waitSecond
               //.Until(d => d.FindElement(By.PartialLinkText("The passwords you entered did not match")));
               .Until(d => d.FindElement(By.XPath("//*[@id=\"main-body\"]/div/div/div[3]/div[1]")));


            List<IWebElement> errormsgs = error.FindElements(By.TagName("li")).ToList();

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
