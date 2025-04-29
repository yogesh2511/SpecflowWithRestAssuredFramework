using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectRestAssured.TrelloApi.Core.Exceptions;
using SpecFlowProjectRestAssured.TrelloApi.Core.Utilities;
using SpecFlowProjectRestAssured.Utility;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Clients
{
    public abstract class BaseTrelloClient
    {
        protected readonly RestClient _client;
        protected readonly ApiLogger _logger;

        protected BaseTrelloClient(ApiLogger logger)
        {
            _client = new RestClient(ConfigurationReader.Settings.BaseUrl);
            _logger = logger;

            // Add Trello auth query params to all requests
            _client.AddDefaultQueryParameter("key", ConfigurationReader.Settings.ApiKey);
            _client.AddDefaultQueryParameter("token", ConfigurationReader.Settings.AuthToken);
        }

        protected async Task<T> ExecuteAsync<T>(RestRequest request)
        {
            _logger.LogInfo($"Sending {request.Method} to {request.Resource}");
            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful)
            {
                _logger.LogError($"Trello API Error: {response.StatusCode} - {response.Content}");
                throw new TrelloException(response.StatusCode, response.Content);
            }

            return response.Data;
        }
    }
}
