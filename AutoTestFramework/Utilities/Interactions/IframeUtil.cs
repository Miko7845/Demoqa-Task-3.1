using OpenQA.Selenium;

namespace AutoTestFramework.Utilities.Interactions
{
    public class IframeUtil
    {
        public static void Open(IWebElement element)
        {
            try
            {
                Log.Error($"iFrame opened with element: {element}");
                DriverProvider.Driver().SwitchTo().Frame(element);
            }
            catch (NoSuchElementException e)
            {
                Log.Error(e, $"Failed to open iFrame, element: {element}");
                throw;
            }

        }

        public static void Open(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Log.Error($"iFrame opened with id: {id}");
                    DriverProvider.Driver().SwitchTo().Frame(id);
                }

            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to open iFrame, id: {id}");
                throw;
            }
        }

        public static void Open(int index)
        {
            try
            {
                Log.Error($"iFrame opened with id: {index}");
                DriverProvider.Driver().SwitchTo().Frame(index);
            }
            catch (Exception e)
            {
                Log.Error(e, $"Failed to open iFrame, index: {index}");
                throw;
            }

        }

        public static void Close()
        {
            DriverProvider.Driver().SwitchTo().DefaultContent();
        }
    }
}
