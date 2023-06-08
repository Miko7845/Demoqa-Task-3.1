using AutoTestFramework.Utilities;
using OpenQA.Selenium;

namespace AutoTestFramework.BaseEntity.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, string name) : base(locator, name) { }

        public void SetText(string text)
        {
            try
            {
                GetElement().SendKeys(text);
                Log.Info($"Keys '{text}' were successfully sent");
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to SendKeys: {text}");
                throw;
            }
        }
    }
}
