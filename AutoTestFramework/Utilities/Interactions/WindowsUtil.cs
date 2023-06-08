namespace AutoTestFramework.Utilities.Interactions
{
    public static class WindowsUtil
    {
        public static string GetCurrentWindow()
        {
            return DriverProvider.Driver().CurrentWindowHandle;
        }

        public static void CloseCurrentTab()
        {
            try
            {
                var current = GetCurrentWindow();
                DriverProvider.Driver().Close();
                SwitchTab(current);
            }
            catch (Exception e)
            {
                Log.Error(e, "Close current tab");
                throw;
            }
            
        }

        public static void SwitchTab(string originalWindow)
        {
            foreach (string window in DriverProvider.Driver().WindowHandles)
            {
                if (originalWindow != window)
                {
                    DriverProvider.Driver().SwitchTo().Window(window);
                    break;
                }
            }
        }
    }
}
