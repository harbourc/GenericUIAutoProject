using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace GenericUIAutoProject.FactoryClasses
{
    public class FirefoxFactory
    {
        public static IWebDriver Create()
        {
            var profile = new FirefoxOptions();
            return new FirefoxDriver(profile);
        }
    }
}
