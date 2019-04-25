using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GenericUIAutoProject.SeleniumExtensions
{
    public static class WebDriverExtensions
    {

        public static bool ElementExists(this IWebDriver driver, By by)
        {
            return driver.FindElements(by).Count > 0;
        }

        public static void WaitForElementToExist(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.ElementExists(by));
        }

        public static void WaitForPageTitleContains(this IWebDriver driver, string title)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.Title.Contains(title));
        }
    }
}
