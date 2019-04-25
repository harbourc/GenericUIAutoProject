using OpenQA.Selenium;

namespace GenericUIAutoProject.PageObjects
{
    public abstract class BasePageObject
    {
        protected IWebDriver Driver { get; }

        protected BasePageObject(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
