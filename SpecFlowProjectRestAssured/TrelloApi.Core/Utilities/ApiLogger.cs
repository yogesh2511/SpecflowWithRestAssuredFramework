using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Utilities
{
    public class ApiLogger
    {
        public void LogInfo(string message) => Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
        public void LogError(string message) => Console.WriteLine($"[ERROR] {DateTime.Now}: {message}");
    }
}
