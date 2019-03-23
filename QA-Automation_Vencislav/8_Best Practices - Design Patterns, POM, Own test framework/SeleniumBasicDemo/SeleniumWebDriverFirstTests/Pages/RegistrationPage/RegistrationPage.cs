namespace SeleniumWebDriverFirstTests.Pages.RegistrationPage
{
    using OpenQA.Selenium;
    using System.IO;

    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
        }

        public void FillRegistrationForm()
        {
            Type(FirstName, "Ventsislav");
            Type(LastName, "Ivanov");
            this.MatrialStatus.Click();
            this.Hobbies[0].Click();
            this.Hobbies[1].Click();
            CountryOption.SelectByText("Bulgaria");
            MonthOption.SelectByValue("3");
            DayOption.SelectByText("3");
            YearOption.SelectByValue("1989");
            Type(Phone, "359999999999");
            Type(UserName, "BatmanForever");
            Type(Email, "Ivanov8@abv.bg");
            UploadPicButton.Click();
            Driver.SwitchTo().ActiveElement().SendKeys(Path.GetFullPath(@"..\..\..\logo.jpg"));
            Type(Description, "I think I'm Ready with this test!");
            Type(Password, "123456789");
            Type(ConfirmPassword, "123456789");
            SubmitButton.Click();
        }
    }
}
