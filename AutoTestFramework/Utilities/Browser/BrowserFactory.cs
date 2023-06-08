using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace AutoTestFramework.Utilities.Browser
{
    internal static class BrowserFactory
    {
        internal static IWebDriver GetBrowser()
        {
            switch (ConfigManager.CurrentBrowser)
            {
                case "Chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var chromOptions = new ChromeOptions();
                    return new ChromeDriver(chromOptions);
                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    var firefoxOptions = new FirefoxOptions();
                    return new FirefoxDriver(firefoxOptions);
                default: return null;
            }
        }
    }
}
