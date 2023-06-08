using AutoTestFramework.Utilities.Browser;
using AutoTestFramework.Utilities;
using NUnit.Framework;

namespace TestingProject.NUnitTests
{
    public abstract class BaseTest
    {
        [OneTimeSetUp]
        public void BeforeTestRun()
        {
            Log.LoggerConfig();
        }

        [SetUp]
        public void BeforeTestMethod()
        {
            Browser.GoToUrl(ConfigManager.Url);          
        }

        [OneTimeTearDown]
        public void AfterTestMethod()
        {
            Browser.CloseBrowser();
        }
    }
}
