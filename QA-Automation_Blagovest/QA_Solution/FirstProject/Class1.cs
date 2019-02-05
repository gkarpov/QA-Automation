using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Class1
    {
       [Test]
        public void MyFirstTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "http://softuni.bg";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            IWebElement loginButton = wait.Until<IWebElement>

            ((w) => { return w.FindElement(By.LinkText("Вход")); });

            loginButton.Click();

            IWebElement userName = driver.FindElement(By.Name("username"));
            userName.Clear();
            userName.SendKeys("georgi");

            IWebElement password = driver.FindElement(By.Name("password"));
            password.Clear();
            password.SendKeys("yyy");
            //TODO: make the same for pa

            IWebElement login = driver.FindElement(By.XPath("/ html/ body / main / div[2] / div / div[2] / div[1] / form / input[2]"));
            
            //login.Submit();
            login.Click();

            //IWebElement logo = driver.FindElement(By.XPath("//*[@id=\"page-header\"]/div[1]/div/div/div[1]/a/img[2]"));
            //Assert.IsNotNull(logo);
            //Assert.AreEqual(50, logo.Size.Width);


        }


    }
}
