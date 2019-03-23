using NUnit.Framework;

namespace SeleniumWebDriverFirstTests.Pages.RegistrationPage
{
    public static class RegistartionPageAsserter
    {
        public static bool TextAsserter(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.RegistrationMessage.Displayed);
            StringAssert.Contains("Thank you", page.RegistrationMessage.Text);
            return true;
        }
    }
}
