using RestSharp;
using SpecFlowProjectRestAssured.Utility;
using System;
using System.Collections.Generic;

namespace SpecFlowProjectRestAssured.Base
{
    public class BaseAPIClass
    {
        // private static readonly string baseUrl = ConfigurationReader.Settings.BaseUrl;
        // private static readonly string token = ConfigurationReader.Settings.AuthToken;
        // private static readonly string apiKey = ConfigurationReader.Settings.ApiKey;

        // Base API URL and authentication details
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiToken { get; set; }

        public BaseAPIClass()
        {
            BaseUrl = ConfigurationReader.Settings.BaseUrl;
            ApiKey = ValidateEnvironmentVariables.GetApiKey();
            ApiToken = ValidateEnvironmentVariables.GetApiToken();
        }

        private RestClient CreateClient(string requestUri = null)
        {
            var client = new RestClient(requestUri ?? BaseUrl);
            ScenarioContextManager.Current["ApiClient"] = client;
            return client;
        }

        private static RestRequest CreateRequest(Method method, string resource = "", string contentType = "application/json")
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", contentType);
            ScenarioContextManager.Current["ApiRequest"] = request;
            return request;
        }

        private static void LogInfo(string message)
        {
            Logger.Info(message); // Assuming Logger is configured
        }

        public RestResponse GetRequest(string requestURI, string token, string key)
        {
            LogInfo($"Request URI is: {requestURI}");
            var client = CreateClient(requestURI);
            ScenarioContextManager.Current["Apiclient"] = client;
            var request = CreateRequest(Method.Get);
            request.AddParameter("token", token);
            request.AddParameter("key", ApiKey);

            var response = client.Execute(request);
            LogInfo($"Response: {response.Content}");

            ScenarioContextManager.Current["ApiResponse"] = response;
            return response;
        }
    }
}
