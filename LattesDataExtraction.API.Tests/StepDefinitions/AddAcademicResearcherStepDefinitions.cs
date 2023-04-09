using System;
using System.Net.Http.Headers;
using TechTalk.SpecFlow;

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
        public async Task GivenIHaveAXMLFileOfAnAcademicResearcher()
        {
            var filePath = @"C:\useful\researcher.xml";

            using (var multipartFormContent = new MultipartFormDataContent())
            {
                // Load the file and set the file's Content-Type header
                var fileStreamContent = new StreamContent(File.OpenRead(filePath));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("xml");

                // Add the file
                multipartFormContent.Add(fileStreamContent, name: "file", fileName: "researcher");

                // Sent it            
                var response = await _httpClient.PostAsync("https://localhost:32768/WeatherForecast", multipartFormContent);
                response.EnsureSuccessStatusCode();

                var test = await response.Content.ReadAsStringAsync();
            }
        }

        [When(@"I request to Add a new one")]
        public void WhenIRequestToAddANewOne()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see the data extracted")]
        public void ThenIShouldSeeTheDataExtracted()
        {
            throw new PendingStepException();
        }
    }
}