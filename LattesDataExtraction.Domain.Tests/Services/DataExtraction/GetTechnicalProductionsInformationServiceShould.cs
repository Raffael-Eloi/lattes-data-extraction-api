using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using LattesDataExtraction.Domain.Tests.Helpers;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetTechnicalProductionsInformationServiceShould
    {
        private IGetDataInformationService getTechnicalProductionsInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = GetAcademicResearcherFilePath.Get();

            academicResearcherDocument = new XmlDocument();

            getTechnicalProductionsInformationService = new GetTechnicalProductionsInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getTechnicalProductionsInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedNatureOfWork = "MULTIMIDIA";
            string expectedTitle = "Viagens Divertidas";
            int expectedYear = 2000;
            string expectedCountry = "Brasil";
            string expectedLanguage = "Português";
            string expectedPurpose = "Educação Infantil";
            string expectedPlatform = "Windows";
            string expectedAvailability = "RESTRITA";
            string expectedFinancingInstituition = "Centro Universitário Luterano de Palmas";

            Author expectedFirstAuthor = new()
            {
                FullName = "Fabiano Fagundes",
                CitationName = "FAGUNDES, Fabiano;FAGUNDES, FABIANO",
                CNPQId = "7309417394410594"
            };

            Author expectedSecondAuthor = new()
            {
                FullName = "Aislan Max Gomes",
                CitationName = "GOMES, A. M.",
            };

            Assert.That(academicResearcher.TechnicalProductions, Is.Not.Null);

            var technicalProductionVerification = academicResearcher.TechnicalProductions
                .FirstOrDefault(
                    x =>
                        x.NatureOfWork == expectedNatureOfWork &&
                        x.Title == expectedTitle &&
                        x.Year.Year == expectedYear &&
                        x.Country == expectedCountry &&
                        x.Language == expectedLanguage &&
                        x.Purpose == expectedPurpose &&
                        x.Platform == expectedPlatform &&
                        x.Availability == expectedAvailability &&
                        x.FinancingInstituition == expectedFinancingInstituition
                );

            Assert.That(technicalProductionVerification, Is.Not.Null);

            Assert.That(technicalProductionVerification.Authors, Is.Not.Null);

            var isFirstAuthorInListOfAuthors = technicalProductionVerification.Authors
                .FirstOrDefault(
                    author =>
                        author.FullName == expectedFirstAuthor.FullName &&
                        author.CitationName == expectedFirstAuthor.CitationName
                 );

            var isSecondAuthorInListOfAuthors = technicalProductionVerification.Authors
                .FirstOrDefault(
                    author =>
                        author.FullName == expectedSecondAuthor.FullName &&
                        author.CitationName == expectedSecondAuthor.CitationName
                 );

            Assert.Multiple(() =>
            {
                Assert.That(isFirstAuthorInListOfAuthors, Is.Not.Null);
                Assert.That(isSecondAuthorInListOfAuthors, Is.Not.Null);
            });

            #endregion
        }
    }
}