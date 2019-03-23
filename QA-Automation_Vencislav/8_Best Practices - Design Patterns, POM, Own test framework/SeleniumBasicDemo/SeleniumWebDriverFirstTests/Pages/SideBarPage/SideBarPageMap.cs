using OpenQA.Selenium;

namespace SeleniumWebDriverFirstTests.Pages.SideBarPage
{
    public partial class SideBarPage
    {
        public IWebElement RegistrationButton => this.Driver.FindElement(By.Id("menu-item-374"));

        public IWebElement DraggableButton => this.Driver.FindElement(By.Id("menu-item-140"));
    }
}
