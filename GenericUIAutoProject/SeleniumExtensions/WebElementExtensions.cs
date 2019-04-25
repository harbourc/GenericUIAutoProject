using System.Threading;
using OpenQA.Selenium;

namespace GenericUIAutoProject.SeleniumExtensions
{
    public static class WebElementExtensions
    {

        public static void SlowlySendKeys(this IWebElement webElement, string text)
        {
            if (text == null)
            {
                return;
            }
            foreach (var c in text)
            {
                try
                {
                    webElement.SendKeys("" + c);
                }
                catch (StaleElementReferenceException)
                {
                    // can catch exception in the calling method to retry
                    throw new StaleElementReferenceException();
                }

                Thread.Sleep(300);
            }
        }

        public static void ClearAndSlowlySendKeys(this IWebElement webElement, string text)
        {
            if (text == null)
            {
                return;
            }

            // clear using ctrl + a and delete
            webElement.SendKeys(Keys.Control + "a");
            webElement.SendKeys(Keys.Delete);

            Thread.Sleep(1000);
            
            SlowlySendKeys(webElement, text);
        }
    }
}
