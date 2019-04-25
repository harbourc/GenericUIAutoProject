using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace GenericUIAutoProject
{
    public class DriverFactory
    {

        private static DriverFactory _current;

        public static DriverFactory Current => _current ?? (_current = new DriverFactory());

        private DriverFactory()
        {
        }

        public IWebDriver Create(EnvironmentConfiguration configuration)
        {
            IWebDriver driver;
            switch (configuration.Browser)
            {
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "chrome":
                    var options = new ChromeOptions();
                    options.AddArgument("--disable-impl-side-painting"); //To fix no such session exception which appears when running tests for a prolonged period
                    options.AddArgument("--disable-extensions");
                    options.AddArguments("disable-infobars");
                    options.AddArgument("--no-sandbox");
                    driver = new ChromeDriver(options);
                    break;
                case "chrome_headless":
                    var headlessOptions = new ChromeOptions();
                    headlessOptions.AddArgument("--disable-impl-side-painting"); //To fix no such session exception which appears when running tests for a prolonged period
                    headlessOptions.AddArgument("--disable-extensions");
                    headlessOptions.AddArguments("disable-infobars");
                    headlessOptions.AddArgument("--no-sandbox");
                    headlessOptions.AddArgument("--headless");
                    headlessOptions.AddArguments("--disable-gpu");
                    headlessOptions.AddArguments("--window-size=1920,1200");
                    headlessOptions.AddArguments("--allow-insecure-localhost");
                    driver = new ChromeDriver(headlessOptions);
                    break;
                case "firefox":
                    var profile = new FirefoxOptions();
                    driver = new FirefoxDriver(profile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return driver;
        }

    }
}
