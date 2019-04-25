using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace GenericUIAutoProject.FactoryClasses
{
    public static class IEFactory
    {
        public static IWebDriver Create()
        {
            return new InternetExplorerDriver();
        }
    }
}
