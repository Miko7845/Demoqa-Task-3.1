using AutoTestFramework.Utilities.Models;
using Newtonsoft.Json;

namespace AutoTestFramework.Utilities
{
    public static class ConfigManager
    {
        private static readonly string s_pathConfigFile = Path.Combine(Directory.GetCurrentDirectory()) + @"\Utilities\Files\config.json";
        private static ConfigModel s_config => JsonDeserialize();
        public static readonly string Url = s_config.Url;
        public static readonly WaitTime WaitTime = s_config.WaitTime;
        public static readonly string CurrentBrowser = s_config.CurrentBrowser;
        public static readonly BrowserOptons ChromeOptons = s_config.ChromeOptons;
        public static readonly BrowserOptons FirefoxOptons = s_config.FirefoxOptons;
        public static readonly string LogFilePath = s_config.LogFilePath;

        public static ConfigModel JsonDeserialize()
        {
            try
            {
                Log.Info("Starting deserialize config.json");
                return JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(s_pathConfigFile));
            }
            catch(Exception e)
            {
                Log.Error(e, "config.json deserialize ERROR");
                throw;
            }
            
        }
    }
}
