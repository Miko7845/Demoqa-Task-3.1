using AutoTestFramework.BaseEntity.Elements;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoTestFramework.Utilities
{
    public static class ConditionalWait
    {
        private static WebDriverWait s_webDriverWait;


        static ConditionalWait()
        {
            var waitTime = new TimeSpan(ConfigManager.WaitTime.Hours, ConfigManager.WaitTime.Minutes, ConfigManager.WaitTime.Seconds);
            s_webDriverWait  = new WebDriverWait(DriverProvider.Driver(), waitTime);
        }

        public static WebDriverWait Wait()
        {
            return s_webDriverWait;
        }

        public static BaseElement WaitForToBeClickable(BaseElement element)
        {
            s_webDriverWait.Until(ExpectedConditions.ElementToBeClickable(element.GetElement()));
            return element;
        }
    }
}
