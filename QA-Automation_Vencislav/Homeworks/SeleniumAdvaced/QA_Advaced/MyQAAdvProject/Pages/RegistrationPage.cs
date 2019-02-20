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

        //Use for error wait
        public WebDriverWait wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

        public void FillRegistrationForm()
        {

            //this.countrycode.SendKeys("inputEmail");
            //this.country. = new SelectElement(_driver.FindElement(By.Id("inputCountry")));
            //this.customfield1 = new SelectElement(_driver.FindElement(By.Id("customfield1")));
            //this.mobile.SendKeys("inputEmail");



            SafeType(firstName, "Ivan");
            SafeType(this.lastName, "Ivanov");
            SafeType(emailAdr, "ivanov@abv.gd");

            SafeType(phone, "00223344");
            SafeType(company, "Adidas");

            SafeType(addr1, "Centralna str. 31");
            SafeType(addr2, "Centralna str. 33");

            SafeType(city, "Himkovo");
            SafeType(state, "Stolica");
            SafeType(postcode, "1212");

            //country.SelectByText("Bulgaria");

            SafeType(taxid, "1212");

            customfield1.SelectByText("1212");

            //IWebElement mobile = _driver.FindElement(By.Id("customfield2"));

            SafeType(password1, "121212");
            SafeType(password2, "121213");

            this.mailing.Click();

            this.submit.Click();
        }

        private void SafeType(IWebElement element, string text)
        {

            element.Clear();
            element.SendKeys(text);

        }

    }
}
