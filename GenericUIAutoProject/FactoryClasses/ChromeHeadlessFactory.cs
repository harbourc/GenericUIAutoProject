using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GenericUIAutoProject.FactoryClasses
{
    public static class ChromeHeadlessFactory
    {
        public static IWebDriver Create()
        {
            var headlessOptions = new ChromeOptions();
            headlessOptions.AddArgument("--disable-impl-side-painting"); //To fix no such session exception which appears when running tests for a prolonged period
            headlessOptions.AddArgument("--disable-extensions");
            headlessOptions.AddArguments("disable-infobars");
            headlessOptions.AddArgument("--no-sandbox");
            headlessOptions.AddArgument("--headless");
            headlessOptions.AddArguments("--disable-gpu");
            headlessOptions.AddArguments("--window-size=1920,1200");
            headlessOptions.AddArguments("--allow-insecure-localhost");
            return new ChromeDriver(headlessOptions);
        }
    }
}
