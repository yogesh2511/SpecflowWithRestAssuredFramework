using Newtonsoft.Json.Linq;
using System.IO;

namespace SpecFlowProjectRestAssured.Utility
{
    public static class EndpointManager
    {
        private static JObject _endpoints;

        static EndpointManager()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "Resources", "Endpoints.json");
            var json = File.ReadAllText(path);
            _endpoints = JObject.Parse(json);
        }

        public static string GetEndpoint(string key, Dictionary<string, string> pathParams = null)
        {
            var endpoint = _endpoints[key]?.ToString();
            if (endpoint == null)
                throw new KeyNotFoundException($"Endpoint for key '{key}' not found.");

            if (pathParams != null)
            {
                foreach (var param in pathParams)
                {
                    endpoint = endpoint.Replace($"{{{param.Key}}}", param.Value);
                }
            }

            return endpoint;
        }
    }
}
