using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace SpecFlowProjectRestAssured.Utility
{
    public static class Logger
    {
        static Logger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Reports/api-log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Info(string message)
        {
            Log.Information(message);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }

        public static void Debug(string message)
        {
            Log.Debug(message);
        }

        public static void Warn(string message)
        {
            Log.Warning(message);
        }

        public static void Fatal(string message)
        {
            Log.Fatal(message);
        }
    }
}
