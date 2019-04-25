using System;
using OpenQA.Selenium;

namespace GenericUIAutoProject.FactoryClasses
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
                    driver = IEFactory.Create();
                    break;
                case "chrome":
                    driver = ChromeFactory.Create();
                    break;
                case "chrome_headless":
                    driver = ChromeHeadlessFactory.Create();
                    break;
                case "firefox":
                    driver = FirefoxFactory.Create();
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
