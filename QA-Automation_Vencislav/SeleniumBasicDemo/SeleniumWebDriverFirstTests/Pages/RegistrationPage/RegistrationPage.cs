namespace SeleniumWebDriverFirstTests.Pages.RegistrationPage
{
    using OpenQA.Selenium;
    using SeleniumWebDriverFirstTests.Models;
    using System.Collections.Generic;
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

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(FirstName, user.FirstName);
            Type(LastName, user.LastName);
            FillManyOptionElements(MatrialStatus, user.MatrialStatus);
            FillManyOptionElements(Hobbies, user.Hobbies);
            CountryOption.SelectByText(user.Country);
            MonthOption.SelectByValue(user.Month);
            DayOption.SelectByText(user.Day);
            YearOption.SelectByValue(user.Year);
            Type(Phone, user.Phone);
            Type(UserName, user.UserName);
            Type(Email, user.Email);
            UploadPicButton.Click();
            Driver.SwitchTo().ActiveElement().SendKeys(user.PicturePath);
            Type(Description, user.Description);
            Type(Password, user.Password);
            Type(ConfirmPassword, user.ConfirmPassword);
            SubmitButton.Click();
        }

        private void FillManyOptionElements(List<IWebElement> elements, List<bool> values)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if(values[i])
                {
                    elements[i].Click();
                }
            }
        }
    }
}
