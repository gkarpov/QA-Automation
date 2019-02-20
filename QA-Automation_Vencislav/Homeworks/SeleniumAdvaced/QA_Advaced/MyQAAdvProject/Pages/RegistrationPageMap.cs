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

        public IWebElement firstName => _driver.FindElement(By.Id("inputFirstName"));

        public IWebElement lastName => _driver.FindElement(By.Id("inputLastName"));
        public IWebElement emailAdr => _driver.FindElement(By.Id("inputEmail"));

        public IWebElement countrycode => _driver.FindElement(By.XPath("//*[@id=\"containerNewUserSignup\"]/div[2]/div[4]/div/div/div"));
        public IWebElement phone => _driver.FindElement(By.Id("inputPhone"));
        public IWebElement company => _driver.FindElement(By.Id("inputCompanyName"));
        public IWebElement addr1 => _driver.FindElement(By.Id("inputAddress1"));
        public IWebElement addr2 => _driver.FindElement(By.Id("inputAddress2"));

        public IWebElement city => _driver.FindElement(By.Id("inputCity"));
        public IWebElement state => _driver.FindElement(By.Id("stateinput"));
        public IWebElement postcode => _driver.FindElement(By.Id("inputPostcode"));
        //public SelectElement country => new SelectElement(this.Country);

        public IWebElement taxid => _driver.FindElement(By.Id("inputTaxId"));

        public SelectElement customfield1 => new SelectElement(_driver.FindElement(By.Id("customfield1")));
        //public IWebElement mobile => _driver.FindElement(By.Id("customfield2"));

        public IWebElement password1 => _driver.FindElement(By.Id("inputNewPassword1"));
        public IWebElement password2 => _driver.FindElement(By.Id("inputNewPassword2"));

        public IWebElement mailing => _driver.FindElement(By.XPath("//*[@id=\"frmCheckout\"]/div[3]/div/div/span[3]"));
        public IWebElement submit => _driver.FindElement(By.XPath("//*[@id=\"frmCheckout\"]/p/input"));

        public IWebElement error => _driver.FindElement(By.XPath("//*[@id=\"main-body\"]/div/div/div[3]/div[1]"));
        
    }
}
