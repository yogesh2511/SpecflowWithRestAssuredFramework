using TechTalk.SpecFlow;
using SpecFlowProjectRestAssured.Utility;
using FluentAssertions;
using SpecFlowProjectRestAssured.Base;

namespace SpecFlowProjectRestAssured.StepDefinitions
{
    [Binding]
    public class AliasSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BaseAPIClass _baseApiClass; // Add an instance of BaseAPIClass

        public AliasSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _baseApiClass = new BaseAPIClass(); // Initialize the instance
        }

        // Step to store the value with an alias
        [Given(@"I store the value '(.*)' with alias '(.*)'")]
        public void GivenIStoreTheValueWithAlias(string value, string alias)
        {
            // Store the alias in AliasUtility
            AliasUtility.StoreAlias(alias, value);

            // Store the alias value in ScenarioContext for global access
            _scenarioContext[alias] = value;
        }

        // Step to verify if the alias contains the expected value
        [Then(@"The alias '(.*)' should have value '(.*)'")]
        public void ThenTheAliasShouldHaveValue(string alias, string expectedValue)
        {
            // Retrieve the alias value from ScenarioContext
            var actualValue = _scenarioContext[alias] as string;

            // Assert that the retrieved value is the same as the expected value
            actualValue.Should().Be(expectedValue);
        }

        // Step to retrieve and use the alias in a request or another step
        [When(@"User sends GET request to '(.*)' using alias '(.*)'")]
        public void WhenUserSendsGETRequestToUsingAlias(string endpoint, string alias)
        {
            // Optionally retrieve alias from ScenarioContext
            var aliasValue = _scenarioContext.ContainsKey(alias) ? _scenarioContext[alias] as string : null;

            // Use the alias value (if it exists) to modify the request URL or for other purposes
            if (!string.IsNullOrEmpty(aliasValue))
            {
                Console.WriteLine($"Using alias '{alias}' with value '{aliasValue}' for the request.");
            }

            // Send the GET request using the dynamic URL
            var baseUrl = _baseApiClass.BaseUrl;
            string requestUrl = $"{baseUrl}{endpoint}";
            var apiToken = _baseApiClass.ApiToken; // Call the method to get the token
            var apiKey = _baseApiClass.ApiKey; // Call the method to get the key
            var response = _baseApiClass.GetRequest(requestUrl, apiToken, apiKey); // Use the instance
            _scenarioContext["ApiResponse"] = response;
        }
    }
}
