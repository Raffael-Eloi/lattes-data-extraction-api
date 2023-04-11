using System.Net.Http.Headers;
using System.Text.Json;

namespace LattesDataExtraction.API.Tests.StepDefinitions
{
    [Binding]
    public class AddAcademicResearcherStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly HttpClient _httpClient;

        public AddAcademicResearcherStepDefinitions(ScenarioContext scenarioContext, HttpClient httpClient)
        {
            _scenarioContext = scenarioContext;
            _httpClient = httpClient;
        }

        [Given(@"I have a XML File of an Academic Researcher")]
        public void GivenIHaveAXMLFileOfAnAcademicResearcher()
        {
            _scenarioContext["filePath"] = @"C:\useful\researcher.xml";
        }

        [When(@"I request to Add a new one")]
        public async Task WhenIRequestToAddANewOne()
        {
            var filePath = _scenarioContext.Get<string>("filePath");

            using (MultipartFormDataContent multipartFormContent = new())
            {
                StreamContent fileStreamContent = new(File.OpenRead(filePath));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");

                multipartFormContent.Add(fileStreamContent, name: "file", fileName: "researcher");

                var httpResponse = await _httpClient.PostAsync("https://localhost:32768/LattesDataExtraction", multipartFormContent);

                httpResponse.IsSuccessStatusCode.Should().BeTrue();

                var response = JsonSerializer.Deserialize<JsonElement>(httpResponse.Content.ReadAsStream());

                _scenarioContext["response"] = response;
            };
        }

        [Then(@"I should see the data extracted")]
        public void ThenIShouldSeeTheDataExtracted()
        {
            JsonElement response = _scenarioContext.Get<JsonElement>("response");
            
            response.Should().NotBeNull();

            Guid id = response.GetProperty("id").GetGuid();
            string? identifierNumber = response.GetProperty("identifierNumber").GetString();
            string? lattesId = response.GetProperty("lattesId").GetString();

            id.Should().NotBeEmpty();
            identifierNumber.Should().NotBeNullOrEmpty();
            lattesId.Should().NotBeNullOrEmpty();
        }
    }
}