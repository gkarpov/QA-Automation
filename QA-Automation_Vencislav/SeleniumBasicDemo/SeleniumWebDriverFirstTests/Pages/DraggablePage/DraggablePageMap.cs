using OpenQA.Selenium;

namespace SeleniumWebDriverFirstTests.Pages.DraggablePage
{
    public partial class DraggablePage
    {
        public IWebElement DragableObject => this.Driver.FindElement(By.Id("draggable"));

        public IWebElement DropableObject => this.Driver.FindElement(By.Id("draggableview"));

        public IWebElement DropableTarget => this.Driver.FindElement(By.Id("droppableview"));

        public IWebElement DropableTargetAfterAction => this.Driver.FindElement(By.CssSelector(".ui-state-highlight, .ui-widget-content .ui-state-highlight, .ui-widget-header .ui-state-highlight"));
    }
}
