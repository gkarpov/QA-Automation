using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQAAdvProject.Pages
{

    public partial class RegistrationPage
    {
        private IWebDriver _driver;

        public RegistrationPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public string URL { get; set; }

;

        public void FillRegistrationForm()
        {
            this.firstName.SendKeys("Ivan");

            this.lastName.SendKeys("inputLastName");
            this.emailAdr.SendKeys("inputEmail");
            this.countrycode.SendKeys("inputEmail");
            this.phone.SendKeys("inputEmail");
            this.company.SendKeys("inputEmail");
            this.addr1.SendKeys("inputEmail");
            this.addr2.SendKeys("inputEmail");
            this.city.SendKeys("inputEmail");
            this.state.SendKeys("inputEmail");
            this.postcode.SendKeys("inputEmail");
            this.country = new SelectElement(_driver.FindElement(By.Id("inputCountry")));
            this.taxid.SendKeys("inputEmail");
            this.customfield1 = new SelectElement(_driver.FindElement(By.Id("customfield1")));
            this.mobile.SendKeys("inputEmail");
            this.password1.SendKeys("inputEmail");
            this.password2.SendKeys("inputEmail");


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

            //IWebElement mailing = _driver.FindElement(By.PartialLinkText("bootstrap-switch"));
            IWebElement mailing = _driver.FindElement(By.XPath("//*[@id=\"frmCheckout\"]/div[3]/div/div/span[3]"));

            //IWebElement captcha = _driver.FindElement(By.XPath("//*[@id=\"recaptcha - anchor\"]/div[5]"));

            //IWebElement submit = _driver.FindElement(By.PartialLinkText("btn-recaptcha"));
            IWebElement submit = _driver.FindElement(By.XPath("//*[@id=\"frmCheckout\"]/p/input"));

            //IWebElement error = _driver.FindElement(By.XPath("//*[@id=\"main - body\"]/div/div/div[3]/div[1]/ul"));

        }
    }
}
