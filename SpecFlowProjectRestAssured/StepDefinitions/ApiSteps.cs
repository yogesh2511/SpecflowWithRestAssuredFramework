using TechTalk.SpecFlow;
using RestSharp;
using SpecFlowProjectRestAssured.Utility;
using System;
using SpecFlowProjectRestAssured.Base;

namespace SpecFlowProjectRestAssured.StepDefinitions
{
    [Binding]
    public class ApiSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BaseAPIClass _baseApiClass; // Create an instance of BaseAPIClass

        public ApiSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _baseApiClass = new BaseAPIClass(); // Initialize the instance
        }

        // Step to send GET request using alias
        [When(@"User sends GET request to '(.*)' with alias '(.*)'")]
        public void WhenUserSendsGETRequestToWithAlias(string endpoint, string alias)
        {
            // Retrieve the alias value from ScenarioContext (if available)
            var aliasValue = _scenarioContext.ContainsKey(alias) ? _scenarioContext[alias] as string : null;

            // If alias exists, replace the placeholder in the endpoint URL
            if (!string.IsNullOrEmpty(aliasValue))
            {
                // Replace the placeholder {board_id} with the actual alias value in the endpoint URL
                endpoint = endpoint.Replace("{board_id}", aliasValue);
                Console.WriteLine($"Using alias '{alias}' with value '{aliasValue}' in request URL: {endpoint}");
            }
            else
            {
                Console.WriteLine($"Alias '{alias}' not found. Proceeding without alias.");
            }

            // Prepare the full request URL
            string requestUrl = $"{ConfigurationReader.Settings.BaseUrl}{endpoint}";

            // Send the GET request using the instance of BaseAPIClass
            var response = _baseApiClass.GetRequest(requestUrl, _baseApiClass.ApiToken, _baseApiClass.ApiKey);

            // Store response for further validation
            _scenarioContext["ApiResponse"] = response;
        }

        // Step to verify the response status code
        [Then(@"The response status code should be '(.*)'")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            var response = _scenarioContext["ApiResponse"] as RestResponse;
            response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
        }
    }
}
