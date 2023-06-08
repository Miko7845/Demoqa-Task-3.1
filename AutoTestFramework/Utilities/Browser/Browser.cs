namespace AutoTestFramework.Utilities.Browser
{
    public static class Browser
    {
        public static void GoToUrl(string url)
        {
            DriverProvider.Driver().Navigate().GoToUrl(url);
        }

        public static void CloseBrowser()
        {
            DriverProvider.Driver().Quit();
        }
    }
}
