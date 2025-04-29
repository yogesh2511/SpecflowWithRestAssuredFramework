using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectRestAssured.Utility;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Utilities
{
    public static class RequestFactory
    {
        public static RestRequest CreateRequest(
            string resource,
            Method method,
            object? body = null,
            Dictionary<string, string>? queryParams = null
        )
        {
            var request = new RestRequest(resource, method);
            request.AddQueryParameter("key", ConfigurationReader.Settings.ApiKey);
            request.AddQueryParameter("token", ConfigurationReader.Settings.AuthToken);

            if (body != null)
                request.AddJsonBody(body);

            if (queryParams != null)
                foreach (var param in queryParams)
                    request.AddQueryParameter(param.Key, param.Value);

            return request;
        }
    }
}
