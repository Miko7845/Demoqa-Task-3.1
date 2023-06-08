using AutoTestFramework.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutoTestFramework.BaseEntity.Elements
{
    public abstract class BaseElement
    {
        private By _locator;
        private string _name;

        public BaseElement(By locator, string name)
        {
            _locator = locator;
            _name = name;
        }

        public IWebElement GetElement()
        {
            try
            {
                ConditionalWait.Wait().Until(ExpectedConditions.ElementIsVisible(_locator));
                ConditionalWait.Wait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_locator));
                return DriverProvider.Driver().FindElement(_locator);
            }
            catch (NoSuchElementException e)
            {
                Log.Error(e, $"The specified element could not be found: {_name}");
                throw;
            }
        }

        public void Click()
        {
            try
            {
                GetElement().Click();
                Log.Info($"Button: {_name} has clicked");
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to click button: {_name}");
                throw;
            }  
        }

        public string GetText()
        {
            try
            {
                Log.Info($"Getting text from: {_name}");
                return GetElement().Text;
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to get text from: {_name}");
                throw;
            }
        }

        public bool IsDisplayed()
        {
            try
            {
                Log.Info($"Checking an element {_name} for visibility");
                return GetElement().Displayed;
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to validate element: {_name}");
                throw;
            }
            
        }

        public string GetAttribute(string attribute)
        {
            try
            {
                Log.Info($"Getting attribute from: {_name}");
                return GetElement().GetAttribute(attribute);
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to get attribute from: {_name} ");
                throw;
            }         
        }
    }
}
