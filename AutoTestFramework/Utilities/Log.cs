using Serilog;

namespace AutoTestFramework.Utilities
{
    public static class Log
    {
        public static void LoggerConfig()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(ConfigManager.LogFilePath, rollingInterval: RollingInterval.Minute)
                .CreateLogger();
        }

        public static void Info(string message) => Serilog.Log.Information(message);
        public static void Error(string message) => Serilog.Log.Error(message);
        public static void Error(Exception ex, string message) => Serilog.Log.Error(ex, message);
    }
}
