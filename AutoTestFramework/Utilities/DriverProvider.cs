using AutoTestFramework.Utilities.Browser;
using OpenQA.Selenium;

namespace AutoTestFramework.Utilities
{
    public static class DriverProvider
    {
        private static IWebDriver s_driver;

        public static IWebDriver Driver()
        {
            if (s_driver == null)
                s_driver = BrowserFactory.GetBrowser();
            return s_driver;
        }
    }
}
