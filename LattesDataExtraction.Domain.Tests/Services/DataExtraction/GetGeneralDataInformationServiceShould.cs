using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetGeneralDataInformationServiceShould
    {
        private IGetDataInformationService getGeneralDataInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = @"C:\useful\researcher.xml";

            academicResearcherDocument = new XmlDocument();

            getGeneralDataInformationService = new GetGeneralDataInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getGeneralDataInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedFullName = "Fabiano Fagundes";
            string expectedCitationName = "FAGUNDES, Fabiano;FAGUNDES, FABIANO";
            string expectedCountryOfBirth = "Brasil";
            string expectedStateOfBirth = "SC";
            string expectedCityOfBirth = "Florianópolis";
            string expectedCountryCode = "BRA";
            string expectedNationalityCountry = "Brasil";
            string expectedOrcidId = "https://orcid.org/0000-0001-9006-6238";

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.FullName, Is.EqualTo(expectedFullName));
                Assert.That(academicResearcher.CitationName, Is.EqualTo(expectedCitationName));
                Assert.That(academicResearcher.CountryOfBirth, Is.EqualTo(expectedCountryOfBirth));
                Assert.That(academicResearcher.StateOfBirth, Is.EqualTo(expectedStateOfBirth));
                Assert.That(academicResearcher.CityOfBirth, Is.EqualTo(expectedCityOfBirth));
                Assert.That(academicResearcher.CountryCode, Is.EqualTo(expectedCountryCode));
                Assert.That(academicResearcher.NationalityCountry, Is.EqualTo(expectedNationalityCountry));
                Assert.That(academicResearcher.OrcidId, Is.EqualTo(expectedOrcidId));
            });

            #endregion
        }
    }
}