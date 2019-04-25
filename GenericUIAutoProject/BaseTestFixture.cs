using System;
using GenericUIAutoProject.FactoryClasses;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GenericUIAutoProject
{
    public class BaseTestFixture
    {
        public static IWebDriver Driver { get; private set; }

        [SetUp]
        public void BaseTestInitialize()
        {
            try
            {
                if (Driver == null)
                {
                    Driver = DriverFactory.Current.Create(EnvironmentConfiguration.Current);
                }
                TestInitialize();
            }
            catch (Exception e)
            {
                BaseTestCleanup();
                Assert.Fail($"Exception from Initilization: {e.GetType()}\n{e.StackTrace}");
            }
        }

        [TearDown]
        public void BaseTestCleanup()
        {
            try
            {
                TestCleanup();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Warning] Exception from TestCleanup: {e.GetType()}\n{e.StackTrace}");
            }
            finally
            {
                if (Driver != null)
                {
                    //Try blocks to ensure that the driver is set to null even if there are any exceptions while closing/quitting the driver.
                    try { Driver?.Close(); }
                    finally
                    {
                        try { Driver?.Quit(); }
                        finally { Driver = null; }
                    }
                }
            }
        }

        protected virtual void TestInitialize()
        {
        }

        protected virtual void TestCleanup()
        {
        }
    }
}
