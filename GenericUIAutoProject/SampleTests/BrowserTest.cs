using GenericUIAutoProject.PageObjects;
using NUnit.Framework;

namespace GenericUIAutoProject.SampleTests
{
    public class BrowserTest : BaseTestFixture
    {

        private GoogleHomePage _homePage;

        protected override void TestInitialize()
        {
            base.TestInitialize();
            _homePage = new GoogleHomePage(Driver);
        }

        [Test]
        public void ShouldSearchGoogleUsingChrome()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Assert.IsTrue(Driver.Title.Contains("Google"));

            _homePage.Search("UI Automation");
            Assert.IsTrue(Driver.Title.Contains("UI Automation"));
        }

    }
}
