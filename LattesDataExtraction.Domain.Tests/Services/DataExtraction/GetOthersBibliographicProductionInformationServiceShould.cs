using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using LattesDataExtraction.Domain.Tests.Helpers;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetOthersBibliographicProductionInformationServiceShould
    {
        private IGetDataInformationService getOthersBibliographicProductionInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = GetAcademicResearcherFilePath.Get();

            academicResearcherDocument = new XmlDocument();

            getOthersBibliographicProductionInformationService = new GetOthersBibliographicProductionInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getOthersBibliographicProductionInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedNatureOfWork = "Completo";
            string expectedTitle = "Crônica de uma Ditadura Anunciada: 50 anos do Golpe Militar";
            int expectedYear = 2014;
            string expectedCountry = "Brasil";
            string expectedLanguage = "Português";
            string expectedHomePageLink = "http://ulbra-to.br/encena/2014/03/31/Cronica-de-uma-Ditadura-Anunciada-50-anos-do-Golpe-Militar";

            Author expectedFirstAuthor = new()
            {
                FullName = "Fabiano Fagundes",
                CitationName = "FAGUNDES, Fabiano;FAGUNDES, FABIANO",
                CNPQId = "7309417394410594"
            };

            Assert.That(academicResearcher.OthersBibliographicProductions, Is.Not.Null);

            var othersBibliographicProductionVerification = academicResearcher.OthersBibliographicProductions
                .FirstOrDefault(
                    x =>
                        x.NatureOfWork == expectedNatureOfWork &&
                        x.Title == expectedTitle &&
                        x.Year.Year == expectedYear &&
                        x.Country == expectedCountry &&
                        x.Language == expectedLanguage &&
                        x.HomePageLink == expectedHomePageLink
                );

            Assert.That(othersBibliographicProductionVerification, Is.Not.Null);

            Assert.That(othersBibliographicProductionVerification.Authors, Is.Not.Null);

            var isFirstAuthorInListOfAuthors = othersBibliographicProductionVerification.Authors
                .FirstOrDefault(
                    author =>
                        author.FullName == expectedFirstAuthor.FullName &&
                        author.CitationName == expectedFirstAuthor.CitationName
                 );

            Assert.Multiple(() =>
            {
                Assert.That(isFirstAuthorInListOfAuthors, Is.Not.Null);
            });

            #endregion
        }
    }
}