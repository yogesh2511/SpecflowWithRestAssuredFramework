using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using SpecFlowProjectRestAssured.Base;
using SpecFlowProjectRestAssured.Utility;
using TechTalk.SpecFlow;

namespace SpecFlowProjectRestAssured.StepDefinitions.Boards
{
    [Binding]
    public class GetBoardSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BaseAPIClass _baseApiClass; // Create an instance of BaseAPIClass

        public GetBoardSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _baseApiClass = new BaseAPIClass();
        }

        [When(@"User sends GET request to '(.*)'")]
        public void WhenUserSendsGETRequestTo(string endpointKey)
        {
            string memberId = ConfigurationReader.Settings.MemberId; // Convert int to string
            var pathParams = new Dictionary<string, string>
            {
                { "memberId", memberId }
            };

            string endpoint = EndpointManager.GetEndpoint(endpointKey, pathParams);
            string requestUrl = $"{ConfigurationReader.Settings.BaseUrl}{endpoint}";

            var response = _baseApiClass.GetRequest(requestUrl, _baseApiClass.ApiToken, _baseApiClass.ApiKey);
            _scenarioContext["ApiResponse"] = response;
        }
    }
}
