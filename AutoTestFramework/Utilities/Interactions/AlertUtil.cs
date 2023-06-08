using SeleniumExtras.WaitHelpers;

namespace AutoTestFramework.Utilities.Interactions
{
    public class AlertUtil
    {
        public static string GetText()
        {
            try
            {
                Log.Info("Get Alert text");
                ConditionalWait.Wait().Until(ExpectedConditions.AlertIsPresent());
                return DriverProvider.Driver().SwitchTo().Alert().Text;
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to get Alert Text");
                throw;
            }
        }

        public static void Prompt(string str)
        {
            try
            {
                Log.Info("Switch to Alert Prompt");
                ConditionalWait.Wait().Until(ExpectedConditions.AlertIsPresent());
                DriverProvider.Driver().SwitchTo().Alert().SendKeys(str);
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to switch to Alert Prompt");
                throw;
            }
        }

        public static void Close()
        {
            try
            {
                Log.Info("Close Alert");
                ConditionalWait.Wait().Until(ExpectedConditions.AlertIsPresent());
                DriverProvider.Driver().SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to close Alert");
                throw;
            }
            
        }

        public static bool IsPresent()
        {
            try
            {
                DriverProvider.Driver().SwitchTo().Alert();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
