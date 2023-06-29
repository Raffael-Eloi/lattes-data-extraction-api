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

                response.Should().NotBeNull();

                bool success = response.GetProperty("success").GetBoolean();
                success.Should().BeTrue();

                Guid id = response.GetProperty("academicResearcherId").GetGuid();
                id.Should().NotBeEmpty();

                _scenarioContext["academicResearcherId"] = id;
            };
        }

        [When(@"I request the information of the Academic Researcher added")]
        public async Task WhenIRequestTheInformationOfTheAcademicResearcherAdded()
        {
            Guid academicResearcherId = _scenarioContext.Get<Guid>("academicResearcherId");

            var httpResponse = await _httpClient.GetAsync($"https://localhost:32768/LattesDataExtraction?academicResearcherId={academicResearcherId}");

            httpResponse.IsSuccessStatusCode.Should().BeTrue();

            var response = JsonSerializer.Deserialize<JsonElement>(httpResponse.Content.ReadAsStream());

            _scenarioContext["response"] = response[0];
        }


        [Then(@"I should see the data extracted")]
        public void ThenIShouldSeeTheDataExtracted()
        {
            var response = _scenarioContext.Get<JsonElement>("response");

            VerifyIfAcademicResearcherIsValid(response);
        }

        private static void VerifyIfAcademicResearcherIsValid(JsonElement response)
        {
            Guid id = response.GetProperty("id").GetGuid();
            id.Should().NotBeEmpty();

            string? identifierNumber = response.GetProperty("identifierNumber").GetString();
            identifierNumber.Should().NotBeNullOrEmpty();

            string? lattesId = response.GetProperty("lattesId").GetString();
            lattesId.Should().NotBeNullOrEmpty();
        }


        [Given(@"I add three Academic Researchers")]
        public async Task GivenIAddThreeAcademicResearchers()
        {
            GivenIHaveAXMLFileOfAnAcademicResearcher();

            for (int i=0; i<3; i++)
            {
                await WhenIRequestToAddANewOne();
            }
        }

        [When(@"I request all Academic Researchers")]
        public async Task WhenIRequestAllAcademicResearchers()
        {
            var httpResponse = await _httpClient.GetAsync($"https://localhost:32768/LattesDataExtraction");

            httpResponse.IsSuccessStatusCode.Should().BeTrue();

            var response = JsonSerializer.Deserialize<JsonElement>(httpResponse.Content.ReadAsStream());

            _scenarioContext["getAllResponse"] = response;
        }

        [Then(@"I should see all Academic Researchers added")]
        public void ThenIShouldSeeAllAcademicResearchersAdded()
        {
            var response = _scenarioContext.Get<JsonElement>("getAllResponse");

            for (int i = 0; i < 3; i++)
            {
                VerifyIfAcademicResearcherIsValid(response[i]);
            }
        }
    }
}