using AutoTestFramework.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutoTestFramework.BaseEntity.Pages
{
    public abstract class BaseForm
    {
        private By _uniqueLocator;
        public string Name;

        public BaseForm(By uniqueLocator, string name)
        {
            _uniqueLocator = uniqueLocator;
            Name = name;
        }

        public bool IsFormOpened()
        {
            try
            {
                Log.Info($"to validate IsFormOpened: {Name}");
                ConditionalWait.Wait().Until(ExpectedConditions.ElementIsVisible(_uniqueLocator));
                return DriverProvider.Driver().FindElements(_uniqueLocator).Count > 0;
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to validate IsFormOpened: {Name}");
                throw;
            }
        }
    }
}
