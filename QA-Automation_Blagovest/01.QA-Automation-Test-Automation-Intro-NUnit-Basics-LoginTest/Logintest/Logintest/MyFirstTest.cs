using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logintest
{
    public class MyFirstTest
    {
        IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        [Test]
        public void myFirstTest()
            {
            driver.Navigate().GoToUrl("https://softuni.bg");
            driver.FindElement(By.LinkText("Вход")).Click();
            IWebElement userName = driver.FindElement(By.Name("username"));
            userName.Clear();
            userName.SendKeys("username");
            IWebElement userPass = driver.FindElement(By.Name("password"));
            userPass.Clear();
            userPass.SendKeys("password");
            driver.FindElement(By.LinkText("Ок")).Click();
            driver.FindElement(By.XPath("/ html / body / main / div[2] / div / div[2] / div[1] / form / input[2]")).Click();
            IWebElement ErrMessage = driver.FindElement(By.ClassName("validation-summary-errors"));
            Console.Write(ErrMessage.Text);
            Assert.IsTrue(ErrMessage.Text.Contains("Невалидно потребителско име или парола"));
            driver.Close();
            driver.Quit();
            }
    }
}
