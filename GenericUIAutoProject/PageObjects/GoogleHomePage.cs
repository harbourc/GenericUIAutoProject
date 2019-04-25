using GenericUIAutoProject.SeleniumExtensions;
using OpenQA.Selenium;

namespace GenericUIAutoProject.PageObjects
{
    public class GoogleHomePage : BasePageObject
    {
        public GoogleHomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Search(string searchTerm)
        {
            Driver.WaitForElementToExist(Selectors.SearchInput);

            Driver.FindElement(Selectors.SearchInput).SlowlySendKeys(searchTerm);
            Driver.FindElement(Selectors.SearchButton).Click();

            Driver.WaitForPageTitleContains(searchTerm);
        }

        private class Selectors
        {
            public static readonly By SearchInput = By.XPath("//input[@title='Search']");
            public static readonly By SearchButton = By.XPath("//input[@value='Google Search']");
        }
    }
}
