using Newtonsoft.Json;

namespace AutoTestFramework.Utilities.Models
{
    public class ConfigModel
    {
        [JsonProperty("Url")]
        public string Url;

        [JsonProperty("CurrentBrowser")]
        public string CurrentBrowser;

        [JsonProperty("ChromeOption")]
        public BrowserOptons ChromeOptons;

        [JsonProperty("FirefoxOption")]
        public BrowserOptons FirefoxOptons;

        [JsonProperty("ExplicitWait")]
        public WaitTime WaitTime;

        [JsonProperty("LogFilePath")]
        public string LogFilePath;
    }

    public class BrowserOptons
    {
        public string Name;
    }

    public class WaitTime
    {
        public int Hours;
        public int Minutes;
        public int Seconds;
    }
}
