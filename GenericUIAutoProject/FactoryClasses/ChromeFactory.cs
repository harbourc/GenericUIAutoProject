using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GenericUIAutoProject.FactoryClasses
{
    public static class ChromeFactory
    {
        public static IWebDriver Create()
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-impl-side-painting"); //To fix no such session exception which appears when running tests for a prolonged period
            options.AddArgument("--disable-extensions");
            options.AddArguments("disable-infobars");
            options.AddArgument("--no-sandbox");
            return new ChromeDriver(options);
        }
    }
}
