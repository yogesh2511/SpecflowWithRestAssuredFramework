using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;
using SpecFlowProjectRestAssured.Utility;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace SpecFlowProjectRestAssured.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"API Base URL is configured")]
        public void GivenAPIBaseURLIsConfigured()
        {
            var baseUrl = ConfigurationReader.Settings.BaseUrl;
            ScenarioContextManager.Current["BaseUrl"] = baseUrl;
            Console.WriteLine($"[Setup] API Base URL configured: {baseUrl}");
        }

        [Given(@"User is authenticated")]
        public void GivenUserIsAuthenticated()
        {
            var token = ConfigurationReader.Settings.AuthToken;
            var apiKey = ConfigurationReader.Settings.ApiKey;

            ScenarioContextManager.Current["Token"] = token;
            ScenarioContextManager.Current["ApiKey"] = apiKey;

            Console.WriteLine("[Setup] Auth token and API key retrieved and stored in ScenarioContext.");


        }

        private RestResponse GetApiResponse()
        {
            return ScenarioContextManager.Current["ApiResponse"] as RestResponse;
        }

        private RestRequest GetApiRequest()
        {
            return ScenarioContextManager.Current["ApiRequest"] as RestRequest;
        }

        private RestClient GetApiClient()
        {
            return ScenarioContextManager.Current["ApiClient"] as RestClient;
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            var response = GetApiResponse();
            ((int)response.StatusCode).Should().Be(expectedStatusCode);
        }

        [Then(@"the response content type should be '(.*)'")]
        public void ThenTheResponseContentTypeShouldBe(string expectedContentType)
        {
            var response = GetApiResponse();
            response.ContentType.Should().Contain(expectedContentType);
        }

        [Then(@"the response header '(.*)' should be '(.*)'")]
        public void ThenTheResponseHeaderShouldBe(string headerKey, string expectedValue)
        {
            var response = GetApiResponse();
            response.Headers.Should().ContainSingle(h => h.Name == headerKey && h.Value != null && h.Value.ToString() == expectedValue);
        }

        [Then(@"the response body should contain '(.*)'")]
        public void ThenTheResponseBodyShouldContain(string expectedContent)
        {
            var response = GetApiResponse();
            response.Content.Should().Contain(expectedContent);
        }

        [Then(@"User getBoards response matches ""(.*)"" schema")]
        public void ThenUserGetBoardsResponseMatchesSchema(string schemaFileName)
        {
            var response = GetApiResponse();
            response.Should().NotBeNull("Expected API response to be available in scenario context.");

            var content = JToken.Parse(response.Content);

            // Load and validate against JSON schema
            var schemaPath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "Resources", "Schemas", schemaFileName);
            var jsonSchema = JSchema.Parse(File.ReadAllText(schemaPath));
            bool isValid = content.IsValid(jsonSchema, out IList<string> errorMessages);

            isValid.Should().BeTrue($"Schema validation failed. Errors: {string.Join(", ", errorMessages)}");
        }


        [Given("the request has query params:")]
        public void TheRequestHasQueryParam(Table table)
        {
            var request = GetApiRequest();

            foreach (var row in table.Rows)
            {
                request = request.AddQueryParameter(row[0], row[1]);
            }
        }
    }
}
