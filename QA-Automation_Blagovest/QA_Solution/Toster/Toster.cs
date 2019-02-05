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
    public class Toster
    {
        [Test]
        public void MyFirstTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.emag.bg/";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));


            IWebElement search = driver.FindElement(By.Id("searchboxTrigger"));
            
            search.SendKeys("Тостер Star-Light TS-800W");

            IWebElement searchClick = driver.FindElement(By.ClassName("em-search"));

            searchClick.Click();
            
            IWebElement toster = driver.FindElement(By.Id("card_grid")).FindElement(By.XPath("./div[1]"));

            IWebElement cartAdd = toster.FindElement(By.ClassName("em-cart_fill"));

            cartAdd.Click();

            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                        
            IWebElement cartAdded = driver.FindElement(By.XPath("/html/body/div[5]/div/div/div[2]/div/div[3]/a"));

            cartAdded.Click();
            

            IWebElement tosterInCart = driver.FindElement(By.Id("vendorsContainer")).FindElement(By.XPath("./div/div[1]/div/div[2]/div[1]/div[1]/a"));
            
            string str = tosterInCart.GetAttribute("title");


            Assert.AreEqual("Тостер Star-Light TS-800W, 800 W, 2 филии, Регулируема степен на изпичане, Функция размразяване, Инокс", tosterInCart.GetAttribute("title")); 
            
            driver.Close();

            driver.Quit();


        }


    }

    internal class ExpectedConditions
    {
    }
}
