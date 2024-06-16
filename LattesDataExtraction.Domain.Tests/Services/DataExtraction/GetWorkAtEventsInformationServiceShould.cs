using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using LattesDataExtraction.Domain.Tests.Helpers;
using System.Reflection;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetWorkAtEventsInformationServiceShould
    {
        private IGetDataInformationService getWorkAtEventsInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = GetAcademicResearcherFilePath.Get();

            academicResearcherDocument = new XmlDocument();

            getWorkAtEventsInformationService = new GetWorkAtEventsInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getWorkAtEventsInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedNatureOfWork = "COMPLETO";
            string expectedTitle = "EducaXML: um ambiente colaborativo para o desenvolvimento de hiperdocumentos educacionais baseados em XML";
            int expectedWorkYear = 2001;
            string expectedCountry = "Brasil";
            string expectedLanguage = "Português";
            string expectedHomePageLink = "www.ulbra-to.br/encoinfo2001/educaXML.pdf";
            string expectedClassification = "REGIONAL";
            string expectedName = "III Encontro de Estudantes de Informática do Estado do Tocantins";
            string expectedCity = "Palmas";
            int expectedRealizationYear = 2001;
            string expectedAnnalsTitle = "Anais do III Encontro de Estudantes de Informática do Estado do Tocantins - II Encontro de Informática do Estado do Tocantins";
            int expectedInitialPage = 146;
            int expectedFinalPage = 155;
            string expectedPublisherCity = "Palmas";

            Author expectedFirstAuthor = new()
            {
                FullName = "Jackson Gomes de Souza",
                CitationName = "SOUZA, Jackson Gomes de",
                CNPQId = "7022849614714429"
            };

            Author expectedSecondAuthor = new()
            {
                FullName = "Fernando Luiz de Oliveira",
                CitationName = "OLIVEIRA, Fernando Luiz de",
            };

            Assert.That(academicResearcher.WorkAtEvents, Is.Not.Null);

            var workAtEventsVerification = academicResearcher.WorkAtEvents
                .FirstOrDefault(
                    x =>
                        x.Name == expectedName &&
                        x.WorkTitle == expectedTitle &&
                        x.NatureOfWork == expectedNatureOfWork &&
                        x.Country == expectedCountry &&
                        x.City == expectedCity &&
                        x.Language == expectedLanguage &&
                        x.AnnalsTitle == expectedAnnalsTitle &&
                        x.InitialPage == expectedInitialPage &&
                        x.FinalPage == expectedFinalPage &&
                        x.PublisherCity == expectedPublisherCity &&
                        x.Classification == expectedClassification &&
                        x.HomePageLink == expectedHomePageLink &&
                        x.WorkYear.Year == expectedWorkYear &&
                        x.RealizationYear.Year == expectedRealizationYear
                );

            Assert.That(workAtEventsVerification, Is.Not.Null);

            Assert.That(workAtEventsVerification.Authors, Is.Not.Null);

            var isFirstAuthorInListOfAuthors = workAtEventsVerification.Authors
                .FirstOrDefault(
                    author =>
                        author.FullName == expectedFirstAuthor.FullName &&
                        author.CitationName == expectedFirstAuthor.CitationName
                 );

            var isSecondAuthorInListOfAuthors = workAtEventsVerification.Authors
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
